using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class PieCatalogViewModel_Should
    {
        [Test]
        public void Return_Not_Null_PieTappedCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();
            var catalogDataServiceMock = new Mock<ICatalogDataService>();

            var pieDetailViewModel = new PieCatalogViewModel(
                connectivityMock.Object,
                navigationMock.Object,
                dialogogMock.Object,
                catalogDataServiceMock.Object
                );

            var pieTappedCommand = pieDetailViewModel.PieTappedCommand;

            Assert.NotNull(pieTappedCommand);
        }


        [Test]
        public void Return_Not_Null_Pies()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();
            var catalogDataServiceMock = new Mock<ICatalogDataService>();

            var pieDetailViewModel = new PieCatalogViewModel(
                connectivityMock.Object,
                navigationMock.Object,
                dialogogMock.Object,
                catalogDataServiceMock.Object
                );

            var pies = pieDetailViewModel.Pies;

            Assert.NotNull(pies);
        }

    }
}
