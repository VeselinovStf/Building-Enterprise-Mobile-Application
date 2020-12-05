using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class PieDetailViewModel_Should
    {
        [Test]
        public void Return_Not_Null_AddToCartCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();

            var pieDetailsViewModel = new PieDetailViewModel(
                connectivityMock.Object,
                navigationMock.Object,
                dialogogMock.Object
                );

            var addToCartCommand = pieDetailsViewModel.AddToCartCommand;

            Assert.NotNull(addToCartCommand);
        }

        [Test]
        public void Return_Not_Null_ReadDescriptionCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();

            var pieDetailsViewModel = new PieDetailViewModel(
                connectivityMock.Object,
                navigationMock.Object,
                dialogogMock.Object
                );

            var readDescriptionCommand = pieDetailsViewModel.ReadDescriptionCommand;

            Assert.NotNull(readDescriptionCommand);
        }
    }
}
