using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class ShoppingCartViewModel_Should
    {
        [Test]
        public void Return_Not_Null_CheckOutCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();
            var settingsMock = new Mock<ISettingsService>();
            var shopingCartDataServiceMock = new Mock<IShoppingCartDataService>();

            var shoppingCartViewModel = new ShoppingCartViewModel(
                navigationMock.Object,
                shopingCartDataServiceMock.Object,
                settingsMock.Object,
                connectivityMock.Object,
                dialogogMock.Object
                );

            var placeOrderCommand = shoppingCartViewModel.CheckOutCommand;

            Assert.NotNull(placeOrderCommand);
        }

        [Test]
        public async Task Return_Not_Null_ShoppingCartItems_When_Initialized()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();
            var settingsMock = new Mock<ISettingsService>();
            var shopingCartDataServiceMock = new Mock<IShoppingCartDataService>();

            var shoppingCartViewModel = new ShoppingCartViewModel(
               navigationMock.Object,
               shopingCartDataServiceMock.Object,
               settingsMock.Object,
               connectivityMock.Object,
               dialogogMock.Object
               );

            await shoppingCartViewModel.InitializeAsync(new object());

            var order = shoppingCartViewModel.ShoppingCartItems;

            Assert.NotNull(order);
        }
    }
}
