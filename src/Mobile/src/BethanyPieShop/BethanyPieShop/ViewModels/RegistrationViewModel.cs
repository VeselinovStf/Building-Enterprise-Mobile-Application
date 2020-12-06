using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Validation;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        private bool _isValid;

        private ValidatableObject<string> _firstName;
        private ValidatableObject<string> _lastName;
        private ValidatableObject<string> _password;
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _email;

        public RegistrationViewModel(
            IAuthenticationService authenticationService,
            IConnectionService connectionService,
            IDialogService dialogService,
            INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _connectionService = connectionService;
            _dialogService = dialogService;
            _navigationService = navigationService;

            _firstName = new ValidatableObject<string>();
            _lastName = new ValidatableObject<string>();
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            _email = new ValidatableObject<string>();

            AddValidation();
        }

        public ICommand RegisterCommand => new Command(OnRegister);
        public ICommand LoginCommand => new Command(OnLogin);

        public ICommand ValidateFirstNameCommand => new Command(() => ValidateFirstName());
        public ICommand ValidateLastNameCommand => new Command(() => ValidateLastName());
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        public ICommand ValidateEmailCommand => new Command(() => ValidateEmail());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());

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

        public ValidatableObject<string> FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private void OnLogin()
        {
            _navigationService.NavigateToAsync<LoginViewModel>();
        }

        private async void OnRegister()
        {
            if (_connectionService.IsConnected)
            {
                this.IsValid = true;
                IsBusy = true;
                var isValid = Validate();

                if (isValid)
                {
                    try
                    {
                        var registerUserAuthServiceResult = await _authenticationService
                            .RegisterAsync(_firstName.Value, _lastName.Value, _email.Value, _userName.Value, _password.Value);

                        //TODO: Change API Implementation for registration
                        if (registerUserAuthServiceResult.IsAuthenticated)
                        {
                            await _dialogService.ShowDialog("Registration successful", "Message", "OK");

                            await _navigationService.NavigateToAsync<LoginViewModel>();
                        }
                        else
                        {
                            await _dialogService.ShowDialog(
                                "This username/password combination is invalid",
                                "Error registrating you in",
                                "OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO: Mange exeptions logging

                        await _dialogService.ShowDialog(
                               "This username/password combination is invalid",
                               "Error registrating you in",
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


        private bool ValidateFirstName()
        {
            return _firstName.Validate();
        }

        private bool ValidateLastName()
        {
            return _lastName.Validate();
        }

        private bool ValidateEmail()
        {
            return _email.Validate();
        }

        private bool ValidateUserName()
        {
            return _userName.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }

        private bool Validate()
        {
            bool isValidFirstName = _firstName.Validate();
            bool isValidLastName = _lastName.Validate();
            bool isValidUserName = _userName.Validate();
            bool isValidPassword = _password.Validate();
            bool isValidEmail = _email.Validate();

            return ((isValidFirstName && isValidLastName) && (isValidUserName && isValidPassword)) && isValidEmail;
        }

        private void AddValidation()
        {
            _firstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A First Name is required." });
            _lastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A Last Name is required." });
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A User Name is required." });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A Password is required." });
            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A Email is required." });
        }
    }
}