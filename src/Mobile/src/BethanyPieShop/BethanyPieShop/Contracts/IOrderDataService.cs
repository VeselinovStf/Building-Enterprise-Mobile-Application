using BethanyPieShop.Core.Models;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IOrderDataService
    {
        Task<Order> AddOrderAsync(Order order);
    }
}
