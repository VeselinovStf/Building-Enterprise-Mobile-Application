using BethanyPieShop.Core.Models;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IShoppingCartDataService
    {
        Task<ShoppingCart> GetShoppingCart(string userId);
        Task<UserShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
    }
}
