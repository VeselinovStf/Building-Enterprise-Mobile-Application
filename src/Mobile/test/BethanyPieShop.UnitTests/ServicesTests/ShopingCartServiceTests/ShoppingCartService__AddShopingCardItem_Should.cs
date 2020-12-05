using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Services.Data;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ServicesTests.ShopingCartServiceTests
{
    [TestFixture]
    public class ShoppingCartService__AddShopingCardItem_Should
    {
        [Test]
        public async Task Return_ShoppingCartItem_When_Correct_Carameters_Are_Passed()
        {
            var userId = "a";
            var mockShoppingCart = ShoppingCardMock
                .GetMockShoppingCart(userId)
                .ShoppingCartItems.ToList()
                .FirstOrDefault();

            var userShoppingCartItem = new UserShoppingCartItem()
            {
                ShoppingCartItem = mockShoppingCart,
                UserId = userId
            };

            var requestProviderMock = new Mock<IRequestProvider>();

            requestProviderMock
                .Setup(e => e.PostAsync<UserShoppingCartItem>(It.IsAny<string>(), It.IsAny<UserShoppingCartItem>(), It.IsAny<string>()))
                .Returns(Task.FromResult<UserShoppingCartItem>(userShoppingCartItem));

            var shoppingCartDataService = new ShoppingCartDataService(requestProviderMock.Object);

            var shoppingCartOrderResult = await shoppingCartDataService.AddShoppingCartItem(mockShoppingCart, userId);

            Assert.NotNull(shoppingCartOrderResult);
            Assert.AreEqual(shoppingCartOrderResult.UserId, userId);
            Assert.NotNull(shoppingCartOrderResult.ShoppingCartItem);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Throws_When_Invalid_UserId_Is_Passed(string userId)
        {
            var mockShoppingCart = ShoppingCardMock
                .GetMockShoppingCart(userId)
                .ShoppingCartItems.ToList()
                .FirstOrDefault();

            var userShoppingCartItem = new UserShoppingCartItem()
            {
                ShoppingCartItem = mockShoppingCart,
                UserId = userId
            };

            var requestProviderMock = new Mock<IRequestProvider>();

            requestProviderMock
                .Setup(e => e.PostAsync<UserShoppingCartItem>(It.IsAny<string>(), It.IsAny<UserShoppingCartItem>(), It.IsAny<string>()))
                .Returns(Task.FromResult<UserShoppingCartItem>(userShoppingCartItem));

            var shoppingCartDataService = new ShoppingCartDataService(requestProviderMock.Object);

            Assert.ThrowsAsync<ShoppingCartDataServiceException>(
                async () => await shoppingCartDataService.AddShoppingCartItem(mockShoppingCart, userId));
        }

        public void Throws_When_ShoppingCartItem_Is_Null()
        {
            var userId = "a";
            ShoppingCartItem shoppingItem = null;

            var userShoppingCartItem = new UserShoppingCartItem()
            {
                ShoppingCartItem = shoppingItem,
                UserId = userId
            };

            var requestProviderMock = new Mock<IRequestProvider>();

            requestProviderMock
                .Setup(e => e.PostAsync<UserShoppingCartItem>(It.IsAny<string>(), It.IsAny<UserShoppingCartItem>(), It.IsAny<string>()))
                .Returns(Task.FromResult<UserShoppingCartItem>(userShoppingCartItem));

            var shoppingCartDataService = new ShoppingCartDataService(requestProviderMock.Object);

            Assert.ThrowsAsync<ShoppingCartDataServiceException>(
                async () => await shoppingCartDataService.AddShoppingCartItem(shoppingItem, userId));
        }
    }
}
