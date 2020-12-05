using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.General
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            //TODO: Implement Navigation
            throw new System.NotImplementedException();
        }
    }
}
