using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Services.General
{
    public class NavigationService : INavigationService
    {
        public void ClearBackStack()
        {
            throw new System.NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            //TODO: Implement Navigation
            throw new System.NotImplementedException();
        }

        public Task NavigateToAsync(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
