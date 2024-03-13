using AnperoModels;
using Microsoft.Extensions.Options;
using ServiceStack.Configuration;
using ServiceStack.Redis;

namespace Anpero.Ultil.Caching
{
    internal class RedisCacheProvider : ICacheService
    {
        readonly RedisEndpoint _endPoint;        
        public RedisCacheProvider(AppSettings appSettings)
        {
            
           _endPoint = new RedisEndpoint(appSettings.RedisServerIp, appSettings.RedisPort??0, appSettings.RedisPass);
        }
        public void Set<T>(string key, T value)
        {
            this.Set(key, value, 0);

        }
        /// <summary>
        /// set redis cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minuteTimeout">minuteTimeout is set max value</param>
        public void Set<T>(string key, T value, double minuteTimeout)
        {
            TimeSpan timeOut = TimeSpan.FromMinutes(minuteTimeout);
            if (minuteTimeout == 0)
            {
                timeOut = TimeSpan.MaxValue;
            }
            else
            {
                timeOut = TimeSpan.FromMinutes(minuteTimeout);
            }
            using (RedisClient client = new RedisClient(_endPoint))
            {
                client.Set(key, value, timeOut);             
            }
        }
      
        public bool TryGet<T>(string key, out T? outPut)
        {
            T? result = default(T);

            try
            {
                using (RedisClient client = new RedisClient(_endPoint))
                {
                    var wrapper = client.As<T>();
                    result = wrapper.GetValue(key);
                }

            }
            catch (Exception)
            {

            }
            outPut = result == null ? default(T) : result;
            return result == null ? false : true;
        }

        public bool Remove(string key)
        {
            bool removed = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                removed = client.Remove(key);
            }

            return removed;
        }
        public bool ResetAllCache()
        {
            try
            {
                using (RedisClient client = new RedisClient(_endPoint))
                {
                    var keyList = client.GetAllKeys();
                    if (keyList != null)
                    {
                        foreach (var item in keyList)
                        {
                            client.Remove(item);
                        }
                    }
                }
                return true;
            }
            catch
            {

            }

            return false;
        }
       
    }
}
