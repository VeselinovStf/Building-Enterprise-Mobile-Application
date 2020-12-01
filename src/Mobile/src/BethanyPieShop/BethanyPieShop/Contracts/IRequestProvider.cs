using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IRequestProvider
    {
        Task<T> GetAsync<T>(string uri, string authToken = "");
    }
}
