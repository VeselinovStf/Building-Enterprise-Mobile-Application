using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IRequestProvider
    {
        Task<T> GetAsync<T>(string uri, string authToken = "");
        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data, string authToken = "");
        Task<T> PostAsync<T>(string uri, T data, string authToken = "");
    }
}
