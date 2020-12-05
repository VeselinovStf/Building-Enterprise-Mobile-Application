using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class LoginViewModel_Should
    {
        [Test]
        public void Not_Return_Null_LoginCommand()
        {
            var authenticationService = new Mock<IAuthenticationService>();
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();

            var loginWiewModel = new LoginViewModel(authenticationService.Object,
                connectivityMock.Object,
                dialogogMock.Object,
                settingsMock.Object,
                navigationMock.Object);

            var loginCommand = loginWiewModel.LoginCommand;

            Assert.NotNull(loginCommand);
        }

        [Test]
        public void Not_Return_Null_RegisterCommand()
        {
            var authenticationService = new Mock<IAuthenticationService>();
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var settingsMock = new Mock<ISettingsService>();
            var navigationMock = new Mock<INavigationService>();

            var loginWiewModel = new LoginViewModel(authenticationService.Object,
                connectivityMock.Object,
                dialogogMock.Object,
                settingsMock.Object,
                navigationMock.Object);

            var loginCommand = loginWiewModel.RegisterCommand;

            Assert.NotNull(loginCommand);
        }
    }
}
