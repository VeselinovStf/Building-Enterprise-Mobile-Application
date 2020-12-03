using BethanyPieShop.Core.Constants.CacheStrategy;
using BethanyPieShop.Core.Constants.Service.Data;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.Data
{
    public class CatalogDataService : ICatalogDataService
    {
        private readonly IRequestProvider _request;
        private readonly IBaseCacheStrategy _cache;

        public CatalogDataService(
            IRequestProvider request,
            IBaseCacheStrategy cache )
        {
            _request = request;
            _cache = cache;
        }

        public async Task<IList<Pie>> GetAllPiesAsync()
        {
            try
            {
                var cachePies = await _cache.GetCache<List<Pie>>(CacheNameContants.AllPies);

                if (cachePies != null)
                {
                    return cachePies;
                }

                UriBuilder uri = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.CatalogEndpoint
                };

                var requestResult = await _request.GetAsync<IList<Pie>>(uri.ToString());

                await _cache.InsertObject(CacheNameContants.AllPies, requestResult, DateTimeOffset.Now.AddSeconds(20));

                return requestResult;
            }
            catch (Exception ex)
            {
                throw new CatalogDataServiceException(ex.Message);
            }
        }

        public async Task<IList<Pie>> GetPiesOfTheWeekAsync()
        {
            try
            {
                List<Pie> piesFromCache = await _cache.GetCache<List<Pie>>(CacheNameContants.PiesOfTheWeek);

                if (piesFromCache != null)
                {
                    return piesFromCache;
                }

                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.PiesOfTheWeekEndpoint
                };

                var pies = await _request.GetAsync<List<Pie>>(builder.ToString());

                await _cache.InsertObject(CacheNameContants.PiesOfTheWeek, pies, DateTimeOffset.Now.AddSeconds(20));

                return pies;
            }
            catch (Exception ex)
            {

                throw new CatalogDataServiceException(ex.Message);
            }
           
        }
    }
}
