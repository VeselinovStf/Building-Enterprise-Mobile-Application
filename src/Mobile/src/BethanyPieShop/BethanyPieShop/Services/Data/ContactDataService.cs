using BethanyPieShop.Core.Constants.Service.Data;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Utility;
using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.Data
{
    public class ContactDataService
    {
        private readonly IRequestProvider _request;

        public ContactDataService(IRequestProvider request)
        {
            _request = request;
        }
        public async Task<ContactInfo> AddContactInfoAsync(string message, string email)
        {
            try
            {
                ValidationGuard
                   .StringIsValidRange(message, 5, $"Invalid {nameof(message)}");

                ValidationGuard
                    .StringIsValidRange(email, 4, $"Invalid {nameof(email)}");

                var newContact = new ContactInfo()
                {
                    Email = email,
                    Message = message
                };

                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.CatalogEndpoint
                };

                var requestResult = await _request.PostAsync<ContactInfo>(builder.ToString(), newContact);

                return requestResult;
            }
            catch (Exception ex)
            {

                throw new ContactDataException(ex.Message);
            }
        }
    }
}
