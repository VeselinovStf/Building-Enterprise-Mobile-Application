using BethanyPieShop.Core.Constants.General;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Extensions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IConnectionService _connectionService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly ICatalogDataService _catalogDataService;

        private ObservableCollection<Pie> _piesOfTheWeak;

        public HomeViewModel(
            IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService,
            ICatalogDataService catalogDataService)
        {
            _connectionService = connectionService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _catalogDataService = catalogDataService;

            PiesOfTheWeak = new ObservableCollection<Pie>();
        }

        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);
        public ICommand AddToCartCommand => new Command<Pie>(OnAddToCart);

        public ObservableCollection<Pie> PiesOfTheWeak
        {
            get => _piesOfTheWeak;
            set
            {
                _piesOfTheWeak = value;
                OnPropertyChanged();
            }
        }

        private void OnPieTapped(Pie selectedPie)
        {
            _navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
        }

        private async void OnAddToCart(Pie selectedPie)
        {
            MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, selectedPie);

            await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
        }

        public override async Task InitializeAsync(object data)
        {
            if (_connectionService.IsConnected)
            {
                try
                {
                    var piesOfTheWeakServiceCall = await _catalogDataService.GetPiesOfTheWeekAsync();

                    PiesOfTheWeak = piesOfTheWeakServiceCall.ToObservableCollection();
                }
                catch (Exception ex)
                {
                    //TODO: Exception logging
                    await _dialogService.ShowDialog(
                        "Unexpected error accures, please try again later",
                        "Try Later",
                        "Ok"
                        );
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
        }
    }
}