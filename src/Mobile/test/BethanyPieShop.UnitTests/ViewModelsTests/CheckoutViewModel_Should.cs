using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class CheckoutViewModel_Should
    {
        [Test]
        public void Return_Not_Null_PlaceOrderCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();
            var settingsMock = new Mock<ISettingsService>();
            var orderDataServiceMock = new Mock<IOrderDataService>();

            var pieDetailsViewModel = new CheckoutViewModel(
                settingsMock.Object,
                dialogogMock.Object,
                navigationMock.Object,
                connectivityMock.Object,
                orderDataServiceMock.Object
                );

            var placeOrderCommand = pieDetailsViewModel.PlaceOrderCommand;

            Assert.NotNull(placeOrderCommand);
        }

        [Test]
        public async Task Return_Not_Null_Order_When_Initialized()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();
            var settingsMock = new Mock<ISettingsService>();
            var orderDataServiceMock = new Mock<IOrderDataService>();

            var pieDetailsViewModel = new CheckoutViewModel(
                settingsMock.Object,
                dialogogMock.Object,
                navigationMock.Object,
                connectivityMock.Object,
                orderDataServiceMock.Object
                );

            await pieDetailsViewModel.InitializeAsync(new object());

            var order = pieDetailsViewModel.Order;

            Assert.NotNull(order);
        }
    }
}
