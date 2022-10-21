namespace Doraemi
{
    public static class Constants
    {
        public static class Category
        {
            public static string Music = "MUSIC";
            public static string Video = "VIDEO";
            public static string Podcast = "PODCAST";
        }

        public static class Subscription
        {
            public static string Start = "START_SUBSCRIPTION";
            public static string Add = "ADD_SUBSCRIPTION";
            public static string End = "PRINT_RENEWAL_DETAILS";
            public static string TopUp = "ADD_TOPUP";

        }

        public static class Pack
        {
            public static string Free = "FREE";
            public static string Personal = "PERSONAL";
            public static string Premium = "PREMIUM";

        }

        public static class Topup
        {
            public static string UptoFour = "FOUR_DEVICE";
            public static string UptoTen = "TEN_DEVICE";
        }


        public static class Error
        {

            public static string Failed = "ADD_SUBSCRIPTION_FAILED";
            public static string NotFound = "SUBSCRIPTIONS_NOT_FOUND";
            public static string InvalidDate = "INVALID_DATE";
            public static string DuplicateCategory = "DUPLICATE_CATEGORY";
            public static string TopupFailed = "ADD_TOPUP_FAILED";
            public static string DuplicateTopup = "DUPLICATE_TOPUP";
            public static string TopUpFourExcedded = "MAXIMUM_FOUR_USERS_ONLY";
            public static string TopUpTenExcedded = "MAXIMUM_TEN_USERS_ONLY";
            public static string Input = "SOMETHING_WRONG_INPUT_PLEASE_CHECK";
        }
    }
}
