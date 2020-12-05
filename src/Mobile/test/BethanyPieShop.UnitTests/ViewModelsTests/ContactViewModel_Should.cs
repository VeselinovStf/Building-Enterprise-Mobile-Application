using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BethanyPieShop.UnitTests.ViewModelsTests
{
    [TestFixture]
    public class ContactViewModel_Should
    {
        [Test]
        public void Return_Not_Null_SubmitMessageCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var contactDataServiceMock = new Mock<IContactDataService>();
            var phoneContactServiceMock = new Mock<IPhoneContactService>();

            var contactViewModel = new ContactViewModel(
                connectivityMock.Object,
                dialogogMock.Object,
                contactDataServiceMock.Object,
                phoneContactServiceMock.Object
                );

            var submitMessageCommand = contactViewModel.SubmitMessageCommand;

            Assert.NotNull(submitMessageCommand);
        }

        [Test]
        public void Return_Not_Null_PhoneCallCommand()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var contactDataServiceMock = new Mock<IContactDataService>();
            var phoneContactServiceMock = new Mock<IPhoneContactService>();

            var contactViewModel = new ContactViewModel(
                connectivityMock.Object,
                dialogogMock.Object,
                contactDataServiceMock.Object,
                phoneContactServiceMock.Object
                );

            var phoneCallCommand = contactViewModel.PhoneCallCommand;

            Assert.NotNull(phoneCallCommand);
        }

        [Test]
        public void Return_Not_Null_Message()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var contactDataServiceMock = new Mock<IContactDataService>();
            var phoneContactServiceMock = new Mock<IPhoneContactService>();

            var contactViewModel = new ContactViewModel(
                connectivityMock.Object,
                dialogogMock.Object,
                contactDataServiceMock.Object,
                phoneContactServiceMock.Object
                );

            var message = contactViewModel.Message;

            Assert.NotNull(message);
        }

        [Test]
        public void MessageContains_Validation()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var contactDataServiceMock = new Mock<IContactDataService>();
            var phoneContactServiceMock = new Mock<IPhoneContactService>();

            var contactViewModel = new ContactViewModel(
                connectivityMock.Object,
                dialogogMock.Object,
                contactDataServiceMock.Object,
                phoneContactServiceMock.Object
                );

            var message = contactViewModel.Message;

            Assert.NotNull(message.Validations);
            Assert.AreEqual(message.Validations.Count, 1);
        }

        [Test]
        public void Return_Not_Null_Email()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var contactDataServiceMock = new Mock<IContactDataService>();
            var phoneContactServiceMock = new Mock<IPhoneContactService>();

            var contactViewModel = new ContactViewModel(
                connectivityMock.Object,
                dialogogMock.Object,
                contactDataServiceMock.Object,
                phoneContactServiceMock.Object
                );

            var email = contactViewModel.Email;

            Assert.NotNull(email);
        }

        [Test]
        public void EmailContains_Validation()
        {
            var connectivityMock = new Mock<IConnectionService>();
            var dialogogMock = new Mock<IDialogService>();
            var contactDataServiceMock = new Mock<IContactDataService>();
            var phoneContactServiceMock = new Mock<IPhoneContactService>();

            var contactViewModel = new ContactViewModel(
                connectivityMock.Object,
                dialogogMock.Object,
                contactDataServiceMock.Object,
                phoneContactServiceMock.Object
                );

            var email = contactViewModel.Email;

            Assert.NotNull(email.Validations);
            Assert.AreEqual(email.Validations.Count, 1);
        }
    }
}
