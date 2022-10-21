using Doraemi.Models;

namespace Doraemi.Service
{
    public class Podcast : IStreamingApp
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
                Amount = 300,
                Months = 3
            };
        }
    }
}