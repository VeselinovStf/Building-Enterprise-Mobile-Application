using Plugin.Connectivity.Abstractions;

namespace BethanyPieShop.Core.Contracts
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        event ConnectivityChangedEventHandler ConnectivityChanged;
    }
}
