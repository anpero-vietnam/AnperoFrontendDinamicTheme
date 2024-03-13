using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Runtime.Caching;
using AnperoModels;
namespace Anpero.Ultil
{
    internal class MemCacheProvider : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        public MemCacheProvider(IMemoryCache memoryCache) {
            _memoryCache = memoryCache;
            
        }   
        public void Set<T>(string cacheKey, T objects)
        {
            try
            {
                _memoryCache.Set(cacheKey, objects,TimeSpan.MaxValue);
            }
            catch (Exception)
            {

            }
        }
        public void Set<T>(string cacheKey, T objects, double cacheMinutes)
        {
            try
            {
                _memoryCache.Set(cacheKey, objects,TimeSpan.FromMinutes(cacheMinutes));

            }
            catch (Exception)
            {

            }
        }
  
        public bool TryGet<T>(string cacheKey, out T? outPut)
        {
            T? _outPut;
            try
            {
                if (_memoryCache.TryGetValue(cacheKey, out _outPut))
                {
                    outPut = _outPut;
                    return true;
                }
                else
                {
                    outPut = default(T);
                    return false;
                }
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
                _memoryCache.Remove(cacheKey);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ResetAllCache()
        {           
            return false;
        }
    }
}