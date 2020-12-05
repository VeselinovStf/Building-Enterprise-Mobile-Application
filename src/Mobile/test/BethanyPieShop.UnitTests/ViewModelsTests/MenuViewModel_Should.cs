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

            var menuItemTappedCommand = menuWiewModel.MenuItemTappedCommand;

            Assert.NotNull(menuItemTappedCommand);
        }

        [Test]
        public void Not_Return_Null_MenuItems()
        {

            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();

            var menuWiewModel = new MenuViewModel(
                navigationMock.Object,
                settingsMock.Object);

            var menuItems = menuWiewModel.MenuItems;

            Assert.NotNull(menuItems);
        }

        [Test]
        public void WelcomeText_Not_Null()
        {

            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();

            var menuWiewModel = new MenuViewModel(
                navigationMock.Object,
                settingsMock.Object);

            var welcomeText = menuWiewModel.WelcomeText;

            Assert.NotNull(welcomeText);
        }
    }
}
