using Hernandes.Customer.Notifications.Localization;

namespace Hernandes.Customer.Notifications.Validations
{
    public partial class Contract<T>
    {
        /// <summary>
        /// Requires a string is null
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNull(string val, string key) =>
            IsNull(val, key, NotificationsErrorMessages.IsNullErrorMessage(key));

        /// <summary>
        /// Requires a string is null
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNull(string val, string key, string message)
        {
            if (val != null)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string is not null
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNotNull(string val, string key) =>
            IsNotNull(val, key, NotificationsErrorMessages.IsNotNullErrorMessage(key));

        /// <summary>
        /// Requires a string is not null
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNotNull(string val, string key, string message)
        {
            if (val == null)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string is null or empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNullOrEmpty(string val, string key) =>
            IsNullOrEmpty(val, key, NotificationsErrorMessages.IsNullOrEmptyErrorMessage(key));

        /// <summary>
        /// Requires a string is null or empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNullOrEmpty(string val, string key, string message)
        {
            if (string.IsNullOrEmpty(val) == false)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string is not null or empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNotNullOrEmpty(string val, string key) =>
            IsNotNullOrEmpty(val, key, NotificationsErrorMessages.IsNotNullOrEmptyErrorMessage(key));

        /// <summary>
        /// Requires a string is not null or empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNotNullOrEmpty(string val, string key, string message)
        {
            if (string.IsNullOrEmpty(val))
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string is null or white space
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNullOrWhiteSpace(string val, string key) =>
            IsNullOrWhiteSpace(val, key, NotificationsErrorMessages.IsNullOrWhiteSpaceErrorMessage(key));

        /// <summary>
        /// Requires a string is null or white space
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNullOrWhiteSpace(string val, string key, string message)
        {
            if (string.IsNullOrWhiteSpace(val) == false)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string is not null or white space
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNotNullOrWhiteSpace(string val, string key) =>
            IsNotNullOrWhiteSpace(val, key, NotificationsErrorMessages.IsNotNullOrWhiteSpaceErrorMessage(key));

        /// <summary>
        /// Requires a string is not null or white space
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNotNullOrWhiteSpace(string val, string key, string message)
        {
            if (string.IsNullOrWhiteSpace(val))
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires two strings are equals
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> AreEquals(string val, string comparer, string key) =>
            AreEquals(val, comparer, key, NotificationsErrorMessages.AreEqualsErrorMessage(val, comparer));

        /// <summary>
        /// Requires two strings are equals
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> AreEquals(string val, string comparer, string key, string message)
        {
            if (val != comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string have a len
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> AreEquals(string val, int comparer, string key) =>
            AreEquals(val, comparer, key, NotificationsErrorMessages.AreEqualsErrorMessage(val, comparer.ToString()));

        /// <summary>
        /// Requires a string have a len
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> AreEquals(string val, int comparer, string key, string message)
        {
            if (val == null)
                return this;

            if (val.Length != comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires two strings are not equals
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> AreNotEquals(string val, string comparer, string key) =>
            AreNotEquals(val, comparer, key, NotificationsErrorMessages.AreNotEqualsErrorMessage(val, comparer));

        /// <summary>
        /// Requires two strings are not equals
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> AreNotEquals(string val, string comparer, string key, string message)
        {
            if (val == comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string do not have a len
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> AreNotEquals(string val, int comparer, string key) =>
            AreNotEquals(val, comparer, key, NotificationsErrorMessages.AreNotEqualsErrorMessage(val, comparer.ToString()));

        /// <summary>
        /// Requires a string do not have a len
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> AreNotEquals(string val, int comparer, string key, string message)
        {
            if (val == null)
                return this;

            if (val.Length == comparer)
                AddNotification(key, message);

            return this;
        }


        /// <summary>
        /// Requires a string contains
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> Contains(string val, string comparer, string key) =>
            Contains(val, comparer, key, NotificationsErrorMessages.ContainsErrorMessage(val, comparer));

        /// <summary>
        /// Requires a string contains
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> Contains(string val, string comparer, string key, string message)
        {
            if (string.IsNullOrEmpty(val))
                val = string.Empty;

            if (val.Contains(comparer) == false)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string not contains
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> NotContains(string val, string comparer, string key) =>
            NotContains(val, comparer, key, NotificationsErrorMessages.NotContainsErrorMessage(val, comparer));

        /// <summary>
        /// Requires a string not contains
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> NotContains(string val, string comparer, string key, string message)
        {
            if (string.IsNullOrEmpty(val))
                val = string.Empty;

            if (val.Contains(comparer))
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string len is greater than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterThan(string val, int comparer, string key) =>
            IsGreaterThan(val, comparer, key, NotificationsErrorMessages.IsGreaterThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a string is greater than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterThan(string val, int comparer, string key, string message)
        {
            if (val == null)
                return this;

            if (val.Length <= comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string len is greater or equals than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterOrEqualsThan(string val, int comparer, string key) =>
            IsGreaterOrEqualsThan(val, comparer, key, NotificationsErrorMessages.IsGreaterOrEqualsThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a string len is greater or equals than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterOrEqualsThan(string val, int comparer, string key, string message)
        {
            if (val == null)
                return this;

            if (val.Length < comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string len is lower than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsLowerThan(string val, int comparer, string key) =>
            IsLowerThan(val, comparer, key, NotificationsErrorMessages.IsLowerThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a string len is lower than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsLowerThan(string val, int comparer, string key, string message)
        {
            if (val == null)
                return this;

            if (val.Length >= comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a string len is lower or equals than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsLowerOrEqualsThan(string val, int comparer, string key) =>
            IsLowerOrEqualsThan(val, comparer, key, NotificationsErrorMessages.IsLowerOrEqualsThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a string len is lower or equals than
        /// </summary>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsLowerOrEqualsThan(string val, int comparer, string key, string message)
        {
            if (val == null)
                return this;

            if (val.Length > comparer)
                AddNotification(key, message);

            return this;
        }
    }
}