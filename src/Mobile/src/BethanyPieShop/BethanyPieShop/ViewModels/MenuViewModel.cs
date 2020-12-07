using BethanyPieShop.Core.Constants.General;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Enumerations;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MainMenuItem> _menuItems;
        private readonly INavigationService _navigationService;
        private readonly ISettingsService _settingsService;

        public MenuViewModel(
            INavigationService navigationService,
           ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
            MenuItems = new ObservableCollection<MainMenuItem>();

            LoadMenuItems();
        }

        public string WelcomeText => "Hello " + _settingsService.UserNameSetting;

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private async void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                _settingsService.UserIdSetting = null;
                _settingsService.UserNameSetting = null;

                MessagingCenter.Send(this, MessagingConstants.LogOut);              
            }

            var type = menuItem?.ViewModelToLoad;
            await _navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Home",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.Home
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Pies",
                ViewModelToLoad = typeof(PieCatalogViewModel),
                MenuItemType = MenuItemType.Pies
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Cart",
                ViewModelToLoad = typeof(ShoppingCartViewModel),
                MenuItemType = MenuItemType.ShoppingCart
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Contact us",
                ViewModelToLoad = typeof(ContactViewModel),
                MenuItemType = MenuItemType.Contact
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Log out",
                ViewModelToLoad = typeof(LoginViewModel),
                MenuItemType = MenuItemType.Logout
            });

        }
    }
}