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
    public class AuthenticationService_Authenticate_Should
    {
        [Test]
        public async Task Authenticate_When_Correct_Parameters_Are_Passed()
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
                ,
                IsAuthenticated = true
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<AuthenticationRequest, AuthenticationResponse>(It.IsAny<string>(), It.IsAny<AuthenticationRequest>(), It.IsAny<string>()))
                .Returns(Task.FromResult<AuthenticationResponse>(requestProviderResult));

            var authenticationService = new AuthenticationService(requestProviderMock.Object);

            var registrationResult = await authenticationService.Authenticate(userName, password);

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

            var authenticationService = new AuthenticationService(requestProviderMock.Object);


            Assert.ThrowsAsync<AuthenticationException>(
                async () => await authenticationService.Authenticate(userName, password));
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

            var authenticationService = new AuthenticationService(requestProviderMock.Object);


            Assert.ThrowsAsync<AuthenticationException>(
                async () => await authenticationService.Authenticate( userName, password));
        }
    }
}
