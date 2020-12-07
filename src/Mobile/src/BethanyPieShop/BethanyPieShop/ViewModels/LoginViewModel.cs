using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Validation;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private readonly ISettingsService _settingsService;
        private readonly INavigationService _navigationService;
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;

        private bool _isValid;

        public LoginViewModel(
            IAuthenticationService authenticationService,
            IConnectionService connectionService,
            IDialogService dialogService,
            ISettingsService settingsService,
            INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _connectionService = connectionService;
            _dialogService = dialogService;
            _settingsService = settingsService;
            _navigationService = navigationService;

            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }

        public ICommand LoginCommand => new Command(OnLogin);
        public ICommand RegisterCommand => new Command(OnRegister);
        public ICommand ValidateUserNameCommand => new Command( ()=> ValidateUserName());
        public ICommand ValidatePasswordCommand => new Command( ()=> ValidatePassword());

        public ValidatableObject<string> UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
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

        private async void OnRegister()
        {
            await _navigationService.NavigateToAsync<RegistrationViewModel>();
        }

        private async void OnLogin()
        {
            this.IsBusy = true;
            this.IsValid = true;
            bool isValid = Validate();

            if (isValid)
            {
                if (_connectionService.IsConnected)
                {
                    try
                    {
                        var authenticationServiceCall = await _authenticationService.Authenticate(UserName.Value, Password.Value);

                        if (authenticationServiceCall.IsAuthenticated)
                        {
                            _settingsService.UserIdSetting = authenticationServiceCall.User.Id;
                            _settingsService.UserNameSetting = authenticationServiceCall.User.UserName;

                            await _navigationService.NavigateToAsync<MainViewModel>();
                        }
                        else
                        {
                            //TODO: Clear Fields

                            await _dialogService.ShowDialog(
                                "This username/password combination isn't known",
                                "Error logging you in",
                                "OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO: Mange exeptions logging
                        //TODO: Clear Fields
                        Debug.WriteLine($"ERROR: {ex.Message}");

                        await _dialogService.ShowDialog(
                            "This username/password combination isn't known",
                            "Error logging you in",
                            "OK");
                    }
                }
                else
                {
                    //TODO: Clear Fields

                    await _dialogService.ShowDialog(
                        "Make shour you are connectet to internet",
                        "No Internet Connection",
                        "Ok"
                        );
                }
            }
            else
            {
                this.IsValid = false;
            }

            this.IsBusy = false;

        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();

            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName()
        {
            return _userName.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            _userName.Validations.Add(new IsTooShortRule<string> { ValidationMessage = "Username length must be minimum of 4 characters." });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
            _password.Validations.Add(new IsTooShortRule<string> { ValidationMessage = "Password length must be minimum of 4 characters." });
        }
    }
}
