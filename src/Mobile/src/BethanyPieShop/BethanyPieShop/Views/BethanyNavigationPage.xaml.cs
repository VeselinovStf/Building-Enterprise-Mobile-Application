
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BethanyPieShop.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BethanyNavigationPage : NavigationPage
    {
        public BethanyNavigationPage()
        {
            InitializeComponent();
        }

        public BethanyNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}