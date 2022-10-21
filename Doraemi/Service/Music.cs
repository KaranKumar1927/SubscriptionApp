using Doraemi.Models;

namespace Doraemi.Service
{
    public class Music : IStreamingApp
    {
        public SubscriptionDetails getFreeSubscription()
        {
            return new SubscriptionDetails()
            {
                Amount = 0,
                Months = 1
            };
        }

        public SubscriptionDetails getPersonalSubscription()
        {
            return new SubscriptionDetails()
            {
                Amount = 100,
                Months = 1
            };
        }

        public SubscriptionDetails getPremiumSubcription()
        {
            return new SubscriptionDetails()
            {
                Amount = 250,
                Months = 3
            };
        }
    }
}