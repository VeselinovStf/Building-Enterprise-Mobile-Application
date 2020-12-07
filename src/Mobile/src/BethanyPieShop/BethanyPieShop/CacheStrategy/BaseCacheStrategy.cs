using Akavache;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.CacheStrategy
{
    public class BaseCacheStrategy : IBaseCacheStrategy
    {
        protected IBlobCache Cache;

        public BaseCacheStrategy(IBlobCache cache = null)
        {
            Cache = cache ?? BlobCache.LocalMachine;
        }

        public async Task<T> GetCache<T>(string cacheName)
        {
            try
            {
                T t = await this.Cache.GetObject<T>(cacheName);

                return t;
            }
            catch (KeyNotFoundException)
            {
                return default(T);
            }
            catch (Exception ex)
            {
                throw new BaseCacheStrategyException(ex.Message);
            }
        }

        public void InvalidateCache<T>()
        {
            this.Cache.InvalidateAllObjects<T>();
        }

        public async Task InsertObject<T>(string cacheName, T entity, DateTimeOffset? offset = null)
        {
            await this.Cache.InsertObject(cacheName, entity, offset);
        }
    }
}
