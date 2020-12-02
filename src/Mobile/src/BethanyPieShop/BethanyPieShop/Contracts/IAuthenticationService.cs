using BethanyPieShop.Core.Models.Responses;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> RegisterAsync(
            string firstName, 
            string lastName, 
            string email,string 
            userName, 
            string password);

        Task<AuthenticationResponse> Authenticate(string userName, string password);

        bool IsAuthenticated();
    }
}
