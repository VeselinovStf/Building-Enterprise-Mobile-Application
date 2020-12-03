using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Models.Requests;
using BethanyPieShop.Core.Models.Responses;
using BethanyPieShop.Core.Services.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ServicesTests.AuthenticationServiceTests
{
    [TestFixture]
    public class AuthenticationService_IsAuthenticated_Should
    {
        [Test]
        public void Return_True_When_User_Is_Authenticated()
        {
            var requestProviderMock = new Mock<IRequestProvider>();

            var settingsMock = new Mock<ISettingsService>();
            settingsMock.Setup(s => s.UserIdSetting).Returns(() => "USER_SETTING");

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

            var registrationResult =  authenticationService.IsAuthenticated();

            Assert.IsTrue(registrationResult);          
        }

        [Test]
        public void Return_False_When_User_Is__Not_Authenticated()
        {
            var requestProviderMock = new Mock<IRequestProvider>();

            var settingsMock = new Mock<ISettingsService>();
            settingsMock.Setup(s => s.UserIdSetting).Returns(() => null);

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

            var registrationResult = authenticationService.IsAuthenticated();

            Assert.IsFalse(registrationResult);
        }
    }
}
