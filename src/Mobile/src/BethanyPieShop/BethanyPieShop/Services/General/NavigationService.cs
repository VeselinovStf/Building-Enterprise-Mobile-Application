using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.General
{
    //TODO: Implement Navigation
    public class NavigationService : INavigationService
    {
        public void ClearBackStack()
        {
            throw new System.NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            
            throw new System.NotImplementedException();
        }

        public Task NavigateToAsync(Type type)
        {
            throw new NotImplementedException();
        }

        public void NavigateToAsync<T>(object parameter) where T : ViewModelBase
        {
            throw new NotImplementedException();
        }
    }
}
