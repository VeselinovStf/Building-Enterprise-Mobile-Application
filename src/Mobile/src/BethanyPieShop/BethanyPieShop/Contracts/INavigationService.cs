using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        void ClearBackStack();
        Task NavigateToAsync(Type type);
        void NavigateToAsync<T>(object parameter) where T : ViewModelBase;
        Task PopToRootAsync();
    }
}
