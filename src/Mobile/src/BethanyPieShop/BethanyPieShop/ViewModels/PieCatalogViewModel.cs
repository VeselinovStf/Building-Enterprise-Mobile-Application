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
    public class PieCatalogViewModel : ViewModelBase
    {
        private readonly IConnectionService _connectionService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly ICatalogDataService _catalogDataService;

        private ObservableCollection<Pie> _pies;

        public PieCatalogViewModel(
            IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService,
            ICatalogDataService catalogDataService)
        {
            _connectionService = connectionService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _catalogDataService = catalogDataService;

            Pies = new ObservableCollection<Pie>();
        }

        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);

        public ObservableCollection<Pie> Pies
        {
            get => _pies;
            set
            {
                _pies = value;
                OnPropertyChanged();
            }
        }

        private void OnPieTapped(Pie selectedPie)
        {
            _navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
        }


        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            if (_connectionService.IsConnected)
            {
                try
                {
                    var piesOfTheWeakServiceCall = await _catalogDataService.GetAllPiesAsync();

                    Pies = piesOfTheWeakServiceCall.ToObservableCollection();
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

            IsBusy = false;
        }
    }
}
