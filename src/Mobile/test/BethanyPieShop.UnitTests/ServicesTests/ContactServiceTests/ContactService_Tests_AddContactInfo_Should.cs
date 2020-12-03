using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Services.Data;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ServicesTests.ContactServiceTests
{
    [TestFixture]
    public class ContactService_Tests_AddContactInfo_Should
    {
        [Test]
        public async Task ShouldReturnInfo_When_Correct_Parrameters_Are_Passed()
        {
            const int contactId = 1;
            const string message = "message";
            const string email = "email@mail.com";

            var contactInfo = new ContactInfo()
            {
                ContactInfoId = contactId,
                Email = email,
                Message = message
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<ContactInfo>(It.IsAny<string>(), It.IsAny<ContactInfo>(),It.IsAny<string>()))
                .Returns(Task.FromResult<ContactInfo>(contactInfo));

            var contactService = new ContactDataService(requestProviderMock.Object);

            var contactServiceResult = await contactService.AddContactInfoAsync(message,email);

            Assert.IsNotNull(contactServiceResult);
            Assert.AreEqual(contactId, contactServiceResult.ContactInfoId);
            Assert.AreEqual(message, contactServiceResult.Message);
            Assert.AreEqual(email, contactServiceResult.Email);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("ads")]
        public void Throws_When_Email_Is_Invalid(string email)
        {
            const int contactId = 1;
            const string message = "message";
            
            var contactInfo = new ContactInfo()
            {
                ContactInfoId = contactId,
                Email = email,
                Message = message
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<ContactInfo>(It.IsAny<string>(), It.IsAny<ContactInfo>(), It.IsAny<string>()))
                .Returns(Task.FromResult<ContactInfo>(contactInfo));

            var contactService = new ContactDataService(requestProviderMock.Object);

            Assert.ThrowsAsync<ContactDataException>(
                async () => await contactService.AddContactInfoAsync(message, email));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("ads3")]
        public void Throws_When_Message_Is_Invalid(string message)
        {
            const int contactId = 1;
            const string email = "email@mail.com";

            var contactInfo = new ContactInfo()
            {
                ContactInfoId = contactId,
                Email = email,
                Message = message
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<ContactInfo>(It.IsAny<string>(), It.IsAny<ContactInfo>(), It.IsAny<string>()))
                .Returns(Task.FromResult<ContactInfo>(contactInfo));

            var contactService = new ContactDataService(requestProviderMock.Object);

            Assert.ThrowsAsync<ContactDataException>(
                async () => await contactService.AddContactInfoAsync(message, email));
        }
    }
}
