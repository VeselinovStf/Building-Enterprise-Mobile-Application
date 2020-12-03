using BethanyPieShop.Core.Constants.Service.Data;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Utility;
using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.Data
{
    public class OrderDataService : IOrderDataService
    {
        private readonly IRequestProvider _request;

        public OrderDataService(IRequestProvider request)
        {
            _request = request;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            try
            {
                ValidationGuard.ObjectIsNull(order, $"Invalid {nameof(order)}");
                ValidationGuard.ObjectIsNull(order.Address, $"Invalid {nameof(order.Address)}");
                ValidationGuard.ObjectIsNull(order.Pies, $"Invalid {nameof(order.Pies)}");

                ValidationGuard
                    .StringIsValidRange(order.OrderId, 1, $"Invalid {order.OrderId}");

                ValidationGuard
                    .StringIsValidRange(order.UserId, 1, $"Invalid {order.OrderId}");

                ValidationGuard
                    .ValueGreatherThen(order.OrderTotal, 0, $"Invalid {order.OrderTotal}");

                ValidationGuard
                    .StringIsValidRange(order.Address.City, 2, $"Invalid {order.Address.City}");

                ValidationGuard
                    .StringIsValidRange(order.Address.Number, 4, $"Invalid {order.Address.Number}");

                 ValidationGuard
                    .StringIsValidRange(order.Address.Street, 4, $"Invalid {order.Address.Street}");

                ValidationGuard
                    .StringIsValidRange(order.Address.ZipCode, 4, $"Invalid {order.Address.ZipCode}");

                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.PlaceOrderEndpoint
                };

                var apiResult = await _request.PostAsync<Order>(builder.ToString(), order);

                return apiResult;

            }
            catch (Exception ex)
            {
                throw new OrderDataServiceException(ex.Message);
            }
        }
    }
}
