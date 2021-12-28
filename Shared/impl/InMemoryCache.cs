using Microsoft.Extensions.Caching.Memory;
using Shared.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.impl
{
    public class InMemoryCache : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string cacheKey) where T : class
        {
            return _memoryCache.Get(cacheKey) as T;
        }

        public void Set(string cacheKey, object item, int minutes)
        {
            if (item != null)
            {
                _memoryCache.Set(cacheKey, item, DateTime.Now. AddMinutes(minutes));
            }
        }
    }
}
