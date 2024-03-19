namespace Anpero
{
    /// <summary>
    /// A cached collection of key value pairs.
    /// </summary>
    public interface ICacheService
    {
        void Set<T>(string key, T value);
        bool TryGet<T>(string cacheKey, out T? outPut);
        void Set<T>(string key, T value, double minuteTimeout);

        bool ResetAllCache();
        bool Remove(string cacheKey);

    }
}
