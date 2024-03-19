using AnperoModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Anpero.Ultil.Caching
{
    public class CacheHelper : ICacheService
    {
        readonly AppSettings appSettings;
        private readonly IMemoryCache _memoryCache;
        public CacheHelper(IOptions<AppSettings> option, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            appSettings = option.Value;
        }

        ICacheService iCacheProvider
        {
            get
            {

                if (appSettings.IsUsingRedisCache)
                {
                    return new RedisCacheProvider(appSettings);
                }
                else
                {
                    return new MemCacheProvider(_memoryCache);
                }
            }

        }


        public void Set<T>(string cacheKey, T objects)
        {
            try
            {
                iCacheProvider.Set<T>(cacheKey, objects);
            }
            catch (Exception)
            {
            }
        }
        public void Set<T>(string cacheKey, T objects, double cacheMinutes)
        {
            try
            {

                iCacheProvider.Set<T>(cacheKey, objects, cacheMinutes);
            }
            catch (Exception)
            {

            }
        }

        public bool TryGet<T>(string cacheKey, out T? outPut)
        {

            try
            {
                return iCacheProvider.TryGet(cacheKey, out outPut);

            }
            catch (Exception)
            {
                outPut = default(T);
                return false;
            }
        }
        public bool Remove(string cacheKey)
        {
            try
            {
                iCacheProvider.Remove(cacheKey);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ResetAllCache()
        {
            try
            {
                iCacheProvider.ResetAllCache();
                return true;
            }
            catch
            { }

            return false;
        }
    }
}
