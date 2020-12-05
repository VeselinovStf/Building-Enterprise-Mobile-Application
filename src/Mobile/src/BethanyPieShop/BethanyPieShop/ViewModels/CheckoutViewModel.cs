using BethanyPieShop.Core.Constants.General;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class CheckoutViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IConnectionService _connectionService;
        private readonly IOrderDataService _orderDataService;

        private Order _order;
        
        public CheckoutViewModel(
            ISettingsService settingsService,
            IDialogService dialogService,
            INavigationService navigationService,
            IConnectionService connectionService,
            IOrderDataService orderDataService)
        {
            _settingsService = settingsService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            _connectionService = connectionService;
            _orderDataService = orderDataService;
        }

        public ICommand PlaceOrderCommand => new Command(OnPlaceOrder);

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }

        private async void OnPlaceOrder(object obj)
        {
            IsBusy = true;

            if (Order == null)
            {
                await _dialogService.ShowDialog(
                           "Your Order is empty! Please select some pies from list",
                           "Empty Order",
                           "Ok"
                           );
            }
            else
            {
                if (_connectionService.IsConnected)
                {
                    try
                    {
                        var placedOrderServiceCall = await _orderDataService
                            .AddOrderAsync(Order);

                        MessagingCenter.Send(this, MessagingConstants.PlaceOrder);

                        await _dialogService.ShowDialog("Order placed successfully", "Success", "OK");
                        await _navigationService.PopToRootAsync();
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
                    await _dialogService.ShowDialog(
                            "Make shour you are connectet to internet",
                            "No Internet Connection",
                            "Ok"
                            );
                }
            }           

            IsBusy = false;
        }

        public override Task InitializeAsync(object data)
        {
            Order = new Order() { Address = new Address(), OrderId = Guid.NewGuid().ToString(), UserId = _settingsService.UserIdSetting };

            return base.InitializeAsync(data);
        }
    }
}
