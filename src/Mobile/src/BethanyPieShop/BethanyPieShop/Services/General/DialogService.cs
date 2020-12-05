using Acr.UserDialogs;
using BethanyPieShop.Core.Contracts;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BethanyPieShop.Core.Services.General
{
    public class DialogService : IDialogService
    {
        public Task ShowDialog(string message, string title, string buttonLabel)
        {
         
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public void ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
    }
}
