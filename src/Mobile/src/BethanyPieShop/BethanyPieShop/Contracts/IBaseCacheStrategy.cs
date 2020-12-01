using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IBaseCacheStrategy
    {
        Task<T> GetCache<T>(string cacheName);
        Task InsertObject<T>(string cacheName, T entity, DateTimeOffset? offset = null);
        void InvalidateCache<T>();
    }
}