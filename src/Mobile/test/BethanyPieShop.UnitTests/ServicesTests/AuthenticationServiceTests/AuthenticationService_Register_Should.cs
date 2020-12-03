using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Models.Requests;
using BethanyPieShop.Core.Models.Responses;
using BethanyPieShop.Core.Services.Data;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ServicesTests.AuthenticationServiceTests
{
    [TestFixture]
    public class AuthenticationService_Register_Should
    {
        [Test]
        public async Task Register_When_Correct_Parrametars_Are_Passed()
        {
            var firstName = "FirstName";
            var lastName = "LastName";
            var email = "mail@mail.com";
            var userName = "UserName";
            var password = "Password";

            var requestProviderResult = new AuthenticationResponse()
            {
                 User = new User()
                 {
                     FirstName = firstName,
                     LastName = lastName,
                     Email = email,
                     UserName = userName
                 }
                ,IsAuthenticated = true
            };

            var requestProviderMock = new Mock<IRequestProvider>();
                requestProviderMock
                    .Setup(e => e.PostAsync<AuthenticationRequest, AuthenticationResponse>(It.IsAny<string>(), It.IsAny<AuthenticationRequest>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<AuthenticationResponse>(requestProviderResult));
            var settingsMock = new Mock<ISettingsService>();

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

            var registrationResult = await authenticationService.RegisterAsync(firstName, lastName, email, userName, password);

            Assert.IsNotNull(registrationResult);
            Assert.IsTrue(registrationResult.IsAuthenticated);
            Assert.IsNotNull(registrationResult.User);
            Assert.AreEqual(firstName, registrationResult.User.FirstName);
            Assert.AreEqual(lastName, registrationResult.User.LastName);
            Assert.AreEqual(email, registrationResult.User.Email);
            Assert.AreEqual(userName, registrationResult.User.UserName);

        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("ads")]
        public void Throws_When_FirstName_Is_Invalid(string testFirstName)
        {
            var firstName = testFirstName;
            var lastName = "LastName";
            var email = "mail@mail.com";
            var userName = "UserName";
            var password = "Password";

            var requestProviderResult = new AuthenticationResponse()
            {
                User = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = userName
                }
                   ,
                IsAuthenticated = true
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<AuthenticationRequest, AuthenticationResponse>(It.IsAny<string>(), It.IsAny<AuthenticationRequest>(), It.IsAny<string>()))
                .Returns(Task.FromResult<AuthenticationResponse>(requestProviderResult));
            var settingsMock = new Mock<ISettingsService>();

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

          
            Assert.ThrowsAsync<AuthenticationDataException>(
                async () => await authenticationService.RegisterAsync(firstName, lastName, email, userName, password));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("ads")]
        public void Throws_When_LastName_Is_Invalid(string testLastName)
        {
            var firstName = "FirstName";
            var lastName = testLastName;
            var email = "mail@mail.com";
            var userName = "UserName";
            var password = "Password";

            var requestProviderResult = new AuthenticationResponse()
            {
                User = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = userName
                }
                 ,
                IsAuthenticated = true
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<AuthenticationRequest, AuthenticationResponse>(It.IsAny<string>(), It.IsAny<AuthenticationRequest>(), It.IsAny<string>()))
                .Returns(Task.FromResult<AuthenticationResponse>(requestProviderResult));
            var settingsMock = new Mock<ISettingsService>();

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

           
            Assert.ThrowsAsync<AuthenticationDataException>(
                async () => await authenticationService.RegisterAsync(firstName, lastName, email, userName, password));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("ads")]
        public void Throws_When_Email_Is_Invalid(string testEmail)
        {
            var firstName = "FirstName";
            var lastName = "LastName";
            var email = testEmail;
            var userName = "UserName";
            var password = "Password";

            var requestProviderResult = new AuthenticationResponse()
            {
                User = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = userName
                }
                   ,
                IsAuthenticated = true
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<AuthenticationRequest, AuthenticationResponse>(It.IsAny<string>(), It.IsAny<AuthenticationRequest>(), It.IsAny<string>()))
                .Returns(Task.FromResult<AuthenticationResponse>(requestProviderResult));
            var settingsMock = new Mock<ISettingsService>();

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

            
            Assert.ThrowsAsync<AuthenticationDataException>(
                async () => await authenticationService.RegisterAsync(firstName, lastName, email, userName, password));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("ads")]
        public void Throws_When_Username_Is_Invalid(string testUserName)
        {
            var firstName = "FirstName";
            var lastName = "LastName";
            var email = "mail@mail.com";
            var userName = testUserName;
            var password = "Password";

            var requestProviderResult = new AuthenticationResponse()
            {
                User = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = userName
                }
                   ,
                IsAuthenticated = true
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<AuthenticationRequest, AuthenticationResponse>(It.IsAny<string>(), It.IsAny<AuthenticationRequest>(), It.IsAny<string>()))
                .Returns(Task.FromResult<AuthenticationResponse>(requestProviderResult));
            var settingsMock = new Mock<ISettingsService>();

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

          
            Assert.ThrowsAsync<AuthenticationDataException>(
                async () => await authenticationService.RegisterAsync(firstName, lastName, email, userName, password));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("ads")]
        public void Throws_When_Password_Is_Invalid(string testPasword)
        {
            var firstName = "FirstName";
            var lastName = "LastName";
            var email = "mail@mail.com";
            var userName = "UserName";
            var password = testPasword;

            var requestProviderResult = new AuthenticationResponse()
            {
                User = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = userName
                }
                  ,
                IsAuthenticated = true
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<AuthenticationRequest, AuthenticationResponse>(It.IsAny<string>(), It.IsAny<AuthenticationRequest>(), It.IsAny<string>()))
                .Returns(Task.FromResult<AuthenticationResponse>(requestProviderResult));
            var settingsMock = new Mock<ISettingsService>();

            var authenticationService = new AuthenticationService(requestProviderMock.Object, settingsMock.Object);

           
            Assert.ThrowsAsync<AuthenticationDataException>(
                async () => await authenticationService.RegisterAsync(firstName, lastName, email, userName, password));
        }


    }
}
