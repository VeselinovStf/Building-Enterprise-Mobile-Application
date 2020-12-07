using BethanyPieShop.Core.Constants.General;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class LogOutViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly INavigationService _navigationService;

        public LogOutViewModel(
            ISettingsService settingsService,
            INavigationService navigationService)
        {
            _settingsService = settingsService;
            _navigationService = navigationService;
        }

        public void InitializeMessaeger()
        {
            MessagingCenter.Subscribe<MenuViewModel>(this, MessagingConstants.LogOut, model => LogOut());
        }

        private async void LogOut()
        {
            _settingsService.UserIdSetting = null;
            _settingsService.UserNameSetting = null;

            //await _navigationService.ClearBackStack();

            await _navigationService.NavigateToAsync<LoginViewModel>();
        }
    }
}
