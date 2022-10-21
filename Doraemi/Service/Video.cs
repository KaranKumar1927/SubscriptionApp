using Doraemi.Models;

namespace Doraemi.Service
{
    public class Video : IStreamingApp
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
                Amount = 200,
                Months = 1
            };
        }

        public SubscriptionDetails getPremiumSubcription()
        {
            return new SubscriptionDetails()
            {
                Amount = 500,
                Months = 3
            };
        }
    }
}