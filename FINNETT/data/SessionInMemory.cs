using System;
using System.Runtime.Caching;

namespace FINNETT.data
{
    public class SessionInMemory
    {
        public static MemoryCache cache = new MemoryCache("FINNETT");

        public static void SaveSessionData(string key, string value)
        {
            try
            {
                CacheItem cacheItem = new CacheItem(key, value);
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
                {
                    SlidingExpiration = TimeSpan.FromMinutes(60)
                };

                bool isExists = cache.Contains(key);

                if (isExists == true)
                {
                    cache.Remove(key);
                }
                bool result = cache.Add(cacheItem, cacheItemPolicy);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void UpdateSessionData(string key, string value)
        {
        }

        public static string GetSessionData(string key)
        {
            string _session = string.Empty;
            bool isExists = cache.Contains(key);

            if (isExists == true)
            {
                _session = cache.Get(key).ToString();
            }
            return _session;
        }

        public static void DeleteSessionData(string key)
        {
            try
            {
                bool isExists = cache.Contains(key);

                if (isExists == true)
                {
                    cache.Remove(key);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteMany(string key)
        {
            try
            {
                bool isExists = cache.Contains(key);

                if (isExists == true)
                {
                    cache.Remove(key);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}