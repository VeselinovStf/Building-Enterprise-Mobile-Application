using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface IDialogService
    {
        Task ShowDialog(string message, string title, string buttonLabel);

        void ShowToast(string message);
    }
}
