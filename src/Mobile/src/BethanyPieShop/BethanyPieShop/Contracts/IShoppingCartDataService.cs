using BethanyPieShop.Core.Models;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IShoppingCartDataService
    {
        Task<ShoppingCart> GetShoppingCart(string userId);
        Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
    }
}
