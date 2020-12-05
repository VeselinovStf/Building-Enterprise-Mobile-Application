using BethanyPieShop.Core.Constants.General;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Validation;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private readonly IContactDataService _contactDataService;
        private readonly IPhoneContactService _phoneContactService;

        private ValidatableObject<string> _message;
        private ValidatableObject<string> _email;

        private bool _isValid;

        public ContactViewModel(
            IConnectionService connectionService,
            IDialogService dialogService,
            IContactDataService contactDataService,
            IPhoneContactService phoneContactService)
        {         
            _connectionService = connectionService;
            _dialogService = dialogService;
            _contactDataService = contactDataService;
            _phoneContactService = phoneContactService;

            _message = new ValidatableObject<string>();
            _email = new ValidatableObject<string>();

            AddValidations();
        }
      
        public ICommand SubmitMessageCommand => new Command(OnSubmitMessage);
        public ICommand PhoneCallCommand => new Command(OnPhoneCall);
       
        public ValidatableObject<string> Message
        {
            get { return _message; }
            set { _message = value; }
        }
       
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        private async void OnPhoneCall()
        {
            try
            {
                _phoneContactService.MakePhoneCall(ContactsConstants.ContactStorePhoneNumber);
            }
            catch (Exception ex)
            {
                //TODO: Mange exeptions logging

                await _dialogService.ShowDialog(
                    "Contact service is unavailible, please try later.",
                    "Try Later",
                    "OK");
            }
        }

        private async void OnSubmitMessage()
        {
            IsBusy = true;

            if (_connectionService.IsConnected)
            {
                this.IsValid = true;
                bool isValid = Validate();
                if (isValid)
                {
                    try
                    {
                        var messageSendServiceCall = await _contactDataService
                            .AddContactInfoAsync(Message.Value, Email.Value);

                        await _dialogService.ShowDialog("Thank you for your comment", "Thank you", "OK");
                    }
                    catch (Exception ex)
                    {
                        //TODO: Mange exeptions logging
                       
                        await _dialogService.ShowDialog(
                            "Contact service is unavailible, please try later.",
                            "Try Later",
                            "OK");
                    }
                }
                else
                {
                    this.IsValid = false;
                }
            }
            else
            {
                await _dialogService.ShowDialog(
                      "Make shour you are connectet to internet",
                      "No Internet Connection",
                      "Ok"
                      );
            }

            IsBusy = false;
        }

        private bool Validate()
        {
            bool isValidMessage = ValidateMessage();
            bool isValidEmail = ValidateEmail();

            return isValidMessage && isValidEmail;
        }

        private bool ValidateMessage()
        {
            return _message.Validate();
        }

        private bool ValidateEmail()
        {
            return _email.Validate();
        }

        private void AddValidations()
        {
            _message.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A message text is required." });
            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A contact email is required." });
        }
    }
}
