using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using System.Collections;
using System.Web;

namespace AIronMan.Services.Providers
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Invalidate(string key);
        void Clear();
    }

    public class DefaultCacheProvider : ICacheProvider
    {
        private ObjectCache Cache { get { return MemoryCache.Default; } }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };

            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return (Cache[key] != null);
        }

        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }


        public void Clear()
        {
            /*System.Web.Caching.Cache Cache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext()) {
                Cache.Remove(enumerator.Key.ToString());*/
            foreach (var item in Cache)
            {
                Invalidate(item.Key);
            }
        }
    }
}
