using BethanyPieShop.Core.Constants.Service.Data;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Utility;
using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.Data
{
    public class ShoppingCartDataService : IShoppingCartDataService
    {
        private readonly IRequestProvider _request;

        public ShoppingCartDataService(IRequestProvider request)
        {
            _request = request;
        }

        public Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ShoppingCart> GetShoppingCart(string userId)
        {
            try
            {
                ValidationGuard
                   .StringIsValidRange(userId, 1, $"Invalid {nameof(userId)}");

                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = $"{ApiConstants.ShoppingCartEndpoint}/{userId}"
                };

                var shoppingCartApiCall = await _request.GetAsync<ShoppingCart>(builder.ToString());

                return shoppingCartApiCall;
            }
            catch (Exception ex)
            {
                throw new ShoppingCartDataServiceException(ex.Message);
            }
        }
    }
}
