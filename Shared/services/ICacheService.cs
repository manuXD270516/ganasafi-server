using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.services
{
    public interface ICacheService
    {
        T Get<T>(string cacheKey) where T : class;
        void Set(string cacheKey, object item, int minutes);
    }
}
