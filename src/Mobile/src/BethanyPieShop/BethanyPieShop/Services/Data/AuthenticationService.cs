﻿using BethanyPieShop.Core.Constants.Service.Data;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models.Requests;
using BethanyPieShop.Core.Models.Responses;
using BethanyPieShop.Core.Utility;
using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestProvider _request;
        private readonly ISettingsService _settingsService;

        public AuthenticationService(
            IRequestProvider request,
            ISettingsService settingsService)
        {
            _request = request;
            _settingsService = settingsService;
        }

        public async Task<AuthenticationResponse> Authenticate(string userName, string password)
        {
            try
            {
                ValidationGuard
                    .StringIsValidRange(userName, 4, $"Invalid {nameof(userName)}");

                ValidationGuard
                    .StringIsValidRange(password, 4, $"Invalid {nameof(password)}");

                var user = new AuthenticationRequest()
                {
                    UserName = userName,
                    Password = password
                };

                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.AuthenticateEndpoint
                };

                var requestResult = await this._request
                    .PostAsync<AuthenticationRequest, AuthenticationResponse>(builder.ToString(), user);

                return requestResult;
            }
            catch (Exception ex)
            {
                throw new AuthenticationDataException(ex.Message);
            }
        }

        public bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(_settingsService.UserIdSetting);
        }

        public async Task<AuthenticationResponse> RegisterAsync(string firstName, string lastName, string email, string userName, string password)
        {
            try
            {
                ValidationGuard
                    .StringIsValidRange(firstName, 4, $"Invalid {nameof(firstName)}");

                ValidationGuard
                    .StringIsValidRange(lastName, 4, $"Invalid {nameof(lastName)}");

                ValidationGuard
                    .StringIsValidRange(email, 4, $"Invalid {nameof(email)}");

                ValidationGuard
                    .StringIsValidRange(userName, 4, $"Invalid {nameof(userName)}");

                ValidationGuard
                    .StringIsValidRange(password, 4, $"Invalid {nameof(password)}");

                var user = new AuthenticationRequest()
                {
                    FirstName = firstName,
                    Email = email,
                    LastName = lastName,
                    UserName = userName,
                    Password = password
                };

                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.RegisterEndpoint
                };

                var requestResult = await this._request
                    .PostAsync<AuthenticationRequest, AuthenticationResponse>(builder.ToString(), user);

                return requestResult;
            }
            catch (Exception ex)
            {
                throw new AuthenticationDataException(ex.Message);
            }
        }
    }
}
