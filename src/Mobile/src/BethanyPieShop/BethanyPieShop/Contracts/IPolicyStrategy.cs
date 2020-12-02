using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IPolicyStrategy
    {
        Task<TResult> WaitToRetryAsyncStrategy<TResult, TRequest>(
            Func<Task<TResult>> executionCall,
            int retryCount = 5);
    }
}
