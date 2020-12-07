using BethanyPieShop.Core.Bootstrap;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BethanyPieShop.Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializeApp();

            InitializeNavigation();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();

            var shoppingCartViewModel = AppContainer.Resolve<ShoppingCartViewModel>();
            shoppingCartViewModel.InitializeMessenger();

            var logOutViewModel = AppContainer.Resolve<LogOutViewModel>();
            logOutViewModel.InitializeMessaeger();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
