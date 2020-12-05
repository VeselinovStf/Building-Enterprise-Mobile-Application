using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using Polly;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.PolicyStrategy
{
    public class PolicyStrategy : IPolicyStrategy
    {
        public async Task<TResult> WaitToRetryAsyncStrategy<TResult, TRequest>(
            Func<Task<TResult>> executionCall,
            int retryCount = 5)
        {
            try
            {
                var responseMessage = await Policy
                    .Handle<WebException>(ex =>
                    {
                        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                        return true;
                    })
                    .WaitAndRetryAsync
                    (
                        retryCount,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                    )
                    .ExecuteAsync(async () => await executionCall());

                return responseMessage;
            }
            catch (Exception ex)
            {
                throw new PolicyStrategyException(ex.Message);
            }
        }
    }
}
