using Doraemi.Models;

namespace Doraemi.Service
{
    public interface IStreamingApp
    {
        SubscriptionDetails getFreeSubscription();
        SubscriptionDetails getPersonalSubscription();
        SubscriptionDetails getPremiumSubcription();
    }
}