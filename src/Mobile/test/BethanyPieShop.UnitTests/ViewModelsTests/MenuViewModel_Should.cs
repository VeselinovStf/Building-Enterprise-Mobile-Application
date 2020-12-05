using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class MenuViewModel_Should
    {
        [Test]
        public void Not_Return_Null_MenuItemTappedCommand()
        {

            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();

            var menuWiewModel = new MenuViewModel(
                navigationMock.Object,
                settingsMock.Object);

            var loginCommand = menuWiewModel.MenuItemTappedCommand;

            Assert.NotNull(loginCommand);
        }
    }
}
