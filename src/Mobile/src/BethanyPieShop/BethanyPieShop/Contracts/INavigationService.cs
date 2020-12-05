using BethanyPieShop.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
    }
}
