using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using Newtonsoft.Json;
using Polly;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.Data
{
    public class RequestProvider : IRequestProvider
    {
        public async Task<T> GetAsync<T>(string uri, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(uri);
                string jsonResult = string.Empty;

                var responseMessage =  await Policy
                     .Handle<WebException>(ex =>
                     {
                         Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                         return true;
                     })
                     .WaitAndRetryAsync
                     (
                         5,
                         retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                     )
                     .ExecuteAsync(async () => await httpClient.GetAsync(uri));

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult =
                        await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(jsonResult);
                }

                throw new HttpRequestExceptionExeption(responseMessage.StatusCode, jsonResult);

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        private HttpClient CreateHttpClient(string token = "") 
        { 
            var httpClient = new HttpClient();
            
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); 
            
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", token); 
            } return httpClient;        
        }

    }
}
