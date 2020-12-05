using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class RegistrationViewModel_Should
    {
        [Test]
        public void Not_Return_Null_LoginCommand()
        {
            var authenticationService = new Mock<IAuthenticationService>();
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();

            var navigationMock = new Mock<INavigationService>();

            var registerWiewModel = new RegistrationViewModel(authenticationService.Object,
                connectivityMock.Object,
                dialogogMock.Object,
                navigationMock.Object);

            var loginCommand = registerWiewModel.LoginCommand;

            Assert.NotNull(loginCommand);
        }

        [Test]
        public void Not_Return_Null_RegisterCommand()
        {
            var authenticationService = new Mock<IAuthenticationService>();
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var navigationMock = new Mock<INavigationService>();

            var registerWiewModel = new RegistrationViewModel(authenticationService.Object,
                connectivityMock.Object,
                dialogogMock.Object,
                navigationMock.Object);

            var registerCommand = registerWiewModel.RegisterCommand;

            Assert.NotNull(registerCommand);
        }
    }
}
