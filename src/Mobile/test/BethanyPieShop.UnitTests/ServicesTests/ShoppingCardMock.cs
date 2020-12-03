using BethanyPieShop.Core.Models;
using System.Collections.Generic;

namespace BethanyPieShop.UnitTests.ServicesTests
{
    public static class ShoppingCardMock
    {
        public static ShoppingCart GetMockShoppingCart(string userId)
        {            
            var shoppingCartId = 1;

            var shoppingCarItems = new List<ShoppingCartItem>()
            {
                 new ShoppingCartItem()
                 {
                      Pie = new Pie { Name = "Apple Pie", Price = 12.95M, ShortDescription = "Our famous apple pies!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg", AllergyInformation = "" },
                      PieId =1,
                      Quantity = 2,
                      ShoppingCartItemId = 1
                 }
            };

            var shoppingCart = new ShoppingCart()
            {
                ShoppingCartId = shoppingCartId,
                ShoppingCartItems = shoppingCarItems,
                UserId = userId
            };

            return shoppingCart;
        }
    }
}
