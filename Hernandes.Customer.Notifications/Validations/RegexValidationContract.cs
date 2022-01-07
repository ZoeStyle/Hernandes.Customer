using System.Text.RegularExpressions;
using Hernandes.Customer.Notifications.Localization;

namespace Hernandes.Customer.Notifications.Validations
{
    public partial class Contract<T>
    {
        /// <summary>
        /// Requires a string matches a regex pattern
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pattern"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> Matches(string val, string pattern, string key) =>
            Matches(val, pattern, key, NotificationsErrorMessages.MatchesErrorMessage(key, pattern));

        /// <summary>
        /// Requires a string matches a regex pattern
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pattern"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> Matches(string val, string pattern, string key, string message)
        {
            if (!Regex.IsMatch(val ?? "", pattern))
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string not matches a regex pattern
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pattern"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> NotMatches(string val, string pattern, string key) =>
            NotMatches(val, pattern, key, NotificationsErrorMessages.NotMatchesErrorMessage(key, pattern));

        /// <summary>
        /// Requires a string not matches a regex pattern
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pattern"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> NotMatches(string val, string pattern, string key, string message)
        {
            if (Regex.IsMatch(val ?? "", pattern))
                AddNotification(key, message);

            return this;
        }
    }
}