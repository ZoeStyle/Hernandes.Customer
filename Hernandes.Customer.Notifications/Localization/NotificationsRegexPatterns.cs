namespace Hernandes.Customer.Notifications.Localization
{
    public static class NotificationsRegexPatterns
    {
        public static string EmailRegexPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public static string UrlRegexPattern = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";
        public static string OnlyNumbersPattern = @"[^0-9]+";
        public static string OnlyLettersAndNumbersPatter = @"[A-Za-z0-9_-]";
        public static string PassportRegexPattern = @"^(?!^0+$)[a-zA-Z0-9]{3,20}$";
        public static string CPFRegexPattern = @"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)";
        public static string RGRegexPattern = @"(^\d{2}).(\d{3}).(\d{3})-(\d{1}$)";
        public static string CNPJRegexPattern = @"(^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$)";
    }
}