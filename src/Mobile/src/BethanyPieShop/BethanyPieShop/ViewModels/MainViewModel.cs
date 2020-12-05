using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private MenuViewModel _menuViewModel;

        public MainViewModel(
            INavigationService navigationService,
            MenuViewModel menuViewModel)
        {
            _navigationService = navigationService;
            _menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get { return _menuViewModel; }
            set 
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}