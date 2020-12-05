using BethanyPieShop.Core.Contracts;
using Plugin.Messaging;

namespace BethanyPieShop.Core.Services.General
{
    public class PhoneContactService : IPhoneContactService
    {
        public void MakePhoneCall(string phoneNumber)
        {
            CrossMessaging.Current.PhoneDialer.MakePhoneCall(phoneNumber);
        }
    }
}
