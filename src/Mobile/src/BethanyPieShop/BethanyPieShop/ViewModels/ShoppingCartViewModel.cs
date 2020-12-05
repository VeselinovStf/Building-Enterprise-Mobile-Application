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
    public class ShoppingCartViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IShoppingCartDataService _shoppingCartDataService;
        private readonly ISettingsService _settingsService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private ObservableCollection<ShoppingCartItem> _shoppingCartItems;

        private decimal _orderTotal;
        private decimal _taxes;
        private decimal _shipping;
        private decimal _grandTotal;

        public ShoppingCartViewModel(
            INavigationService navigationService,
            IShoppingCartDataService shoppingCartDataService,
            ISettingsService settingsService,
            IConnectionService connectionService,
            IDialogService dialogService
            )
        {            
            _navigationService = navigationService;
            _shoppingCartDataService = shoppingCartDataService;
            _settingsService = settingsService;
            _connectionService = connectionService;
            _dialogService = dialogService;

            ShoppingCartItems = new ObservableCollection<ShoppingCartItem>();
        }

        public ICommand CheckOutCommand => new Command(OnCheckOut);

        public ObservableCollection<ShoppingCartItem> ShoppingCartItems
        {
            get => _shoppingCartItems;
            set
            {
                _shoppingCartItems = value;
                RecalculateBasket();
                OnPropertyChanged();
            }
        }

        public decimal GrandTotal
        {
            get => _grandTotal;
            set
            {
                _grandTotal = value;
                OnPropertyChanged();
            }
        }

        public decimal Shipping
        {
            get => _shipping;
            set
            {
                _shipping = value;
                OnPropertyChanged();
            }
        }

        public decimal Taxes
        {
            get => _taxes;
            set
            {
                _taxes = value;
                OnPropertyChanged();
            }
        }

        public void InitializeMessenger()
        {
            MessagingCenter.Subscribe<PieDetailViewModel, Pie>(this, MessagingConstants.AddPieToBasket,
                (pieDetailViewModel, pie) => OnAddPieToBasketReceived(pie));

            MessagingCenter.Subscribe<HomeViewModel, Pie>(this, MessagingConstants.AddPieToBasket,
                (homeViewModel, pie) => OnAddPieToBasketReceived(pie));

            MessagingCenter.Subscribe<CheckoutViewModel>(this, MessagingConstants.PlaceOrder, model => OnOrderPlaced());
        }

        private void OnOrderPlaced()
        {
            ShoppingCartItems.Clear();
        }

        private async void OnAddPieToBasketReceived(Pie pie)
        {
            var shoppingCartItem = new ShoppingCartItem() { Pie = pie, PieId = pie.PieId, Quantity = 1 };
            IsBusy = true;

            if (_connectionService.IsConnected)
            {
                try
                {
                    await _shoppingCartDataService.AddShoppingCartItem(shoppingCartItem, _settingsService.UserIdSetting);

                    ShoppingCartItems.Add(shoppingCartItem);

                    RecalculateBasket();
                }
                catch (Exception ex)
                {
                    //TODO: Mange exeptions logging

                    await _dialogService.ShowDialog(
                               "In this current moment are service is unavailible, try again later",
                               "Error Adding Order",
                               "OK");
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

        private void RecalculateBasket()
        {
            _orderTotal = CalculateOrderTotal();

            Taxes = _orderTotal * (decimal)0.2;
            Shipping = _orderTotal * (decimal)0.1;

            GrandTotal = _orderTotal + _shipping + _taxes;
        }

        private decimal CalculateOrderTotal()
        {
            decimal total = 0;

            foreach (var shoppingCartItem in ShoppingCartItems)
            {
                total += shoppingCartItem.Quantity * shoppingCartItem.Pie.Price;
            }

            return total;
        }

        private async void OnCheckOut()
        {
            await _navigationService.NavigateToAsync<CheckoutViewModel>();
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            if (_connectionService.IsConnected)
            {
                try
                {
                    var shoppingCart = await _shoppingCartDataService.GetShoppingCart(_settingsService.UserIdSetting);

                    ShoppingCartItems = shoppingCart.ShoppingCartItems.ToObservableCollection();
                }
                catch (Exception ex)
                {
                    //TODO: Mange exeptions logging

                    await _dialogService.ShowDialog(
                               "In this current moment are service is unavailible, try again later",
                               "Error Showing Shopping Cart Order",
                               "OK");
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
