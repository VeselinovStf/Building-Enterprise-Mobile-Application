using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class HomeViewModel_Should
    {
        [Test]
        public void Return_Not_Null_PieTappedCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();
            var catalogDataServiceMock = new Mock<ICatalogDataService>();

            var homeViewModel = new HomeViewModel(
                connectivityMock.Object,
                navigationMock.Object,
                dialogogMock.Object,
                catalogDataServiceMock.Object
                );

            var pieTappedCommand = homeViewModel.PieTappedCommand;

            Assert.NotNull(pieTappedCommand);
        }

        [Test]
        public void Return_Not_Null_AddToCartCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();
            var catalogDataServiceMock = new Mock<ICatalogDataService>();

            var homeViewModel = new HomeViewModel(
                connectivityMock.Object,
                navigationMock.Object,
                dialogogMock.Object,
                catalogDataServiceMock.Object
                );

            var addToCartCommandCommand = homeViewModel.AddToCartCommand;

            Assert.NotNull(addToCartCommandCommand);
        }

        [Test]
        public void Return_Not_Null_PiesOfTheWeak()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();
            var catalogDataServiceMock = new Mock<ICatalogDataService>();

            var homeViewModel = new HomeViewModel(
                connectivityMock.Object,
                navigationMock.Object,
                dialogogMock.Object,
                catalogDataServiceMock.Object
                );

            var piesOfTheWeak = homeViewModel.PiesOfTheWeak;

            Assert.NotNull(piesOfTheWeak);
        }

    }
}
