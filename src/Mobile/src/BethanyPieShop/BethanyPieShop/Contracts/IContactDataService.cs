using BethanyPieShop.Core.Models;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IContactDataService
    {
        Task<ContactInfo> AddContactInfoAsync(string message, string email);
    }
}
