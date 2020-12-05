using BethanyPieShop.Core.Constants.General;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BethanyPieShop.Core.ViewModels
{
    public class PieDetailViewModel : ViewModelBase
    {
        private readonly IConnectionService _connectionService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        private Pie _selectedPie;

        public PieDetailViewModel(
            IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService)
        {
            _connectionService = connectionService;
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        public ICommand AddToCartCommand => new Command(OnAddToCart);
        public ICommand ReadDescriptionCommand => new Command(OnReadDescription);

        public Pie SelectedPie
        {
            get { return _selectedPie; }
            set
            {
                _selectedPie = value;
                OnPropertyChanged();
            }
        }

        private async void OnAddToCart()
        {
            if (SelectedPie != null)
            {
                MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, SelectedPie);

                await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
            }
            else
            {
                await _dialogService.ShowDialog("Please select pie before adding to cart", "Select pie first", "OK");
            }
        }

        private void OnReadDescription()
        {
            if (SelectedPie != null)
            {
                DependencyService.Get<ITextToSpeech>().ReadText(SelectedPie.LongDescription);
            }
        }

        public override async Task InitializeAsync(object data)
        {
            SelectedPie = (Pie)data;
        }
    }
}