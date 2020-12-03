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
    public class ShoppingCartService__GetShopingCard_Should
    {
        [Test]
        public async Task Return_ShoppingCart_When_Correct_Carameters_Are_Passed()
        {
            var userId = "a";
            var mockShoppingCart = ShoppingCardMock.GetMockShoppingCart(userId);

            var requestProviderMock = new Mock<IRequestProvider>();

            requestProviderMock
                .Setup(e => e.GetAsync<ShoppingCart>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<ShoppingCart>(mockShoppingCart));

            var orderDataService = new ShoppingCartDataService(requestProviderMock.Object);

            var addedOrderResult = await orderDataService.GetShoppingCart(userId);

            Assert.NotNull(addedOrderResult);
            Assert.AreEqual(addedOrderResult.ShoppingCartId, mockShoppingCart.ShoppingCartId);
            Assert.AreEqual(addedOrderResult.UserId, mockShoppingCart.UserId);
            Assert.NotNull(addedOrderResult.ShoppingCartItems);
            Assert.AreEqual(addedOrderResult.ShoppingCartItems.ToList().Count, 1);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Throws_When_Invalid_UserId_Is_Passed(string userId)
        {
            
            var mockShoppingCart = ShoppingCardMock.GetMockShoppingCart(userId);

            var requestProviderMock = new Mock<IRequestProvider>();

            requestProviderMock
                .Setup(e => e.GetAsync<ShoppingCart>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<ShoppingCart>(mockShoppingCart));

            var orderDataService = new ShoppingCartDataService(requestProviderMock.Object);

            var addedOrderResult = 

            Assert.ThrowsAsync<ShoppingCartDataServiceException>(
                async () => await orderDataService.GetShoppingCart(userId));
        }
    }
}
