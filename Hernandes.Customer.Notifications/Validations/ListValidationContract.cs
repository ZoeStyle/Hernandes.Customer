using System.Collections.Generic;
using System.Linq;
using Hernandes.Customer.Notifications.Localization;

namespace Hernandes.Customer.Notifications.Validations
{
    public partial class Contract<T>
    {
        /// <summary>
        /// Requires a list is null
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNull<TList>(IEnumerable<TList> val, string key) =>
            IsNull(val, key, NotificationsErrorMessages.IsNullErrorMessage(key));

        /// <summary>
        /// Requires a list is null
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNull<TList>(IEnumerable<TList> val, string key, string message)
        {
            if (val != null)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a list is not null
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNotNull<TList>(IEnumerable<TList> val, string key) =>
            IsNull(val, key, NotificationsErrorMessages.IsNotNullErrorMessage(key));

        /// <summary>
        /// Requires a list is not null
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNotNull<TList>(IEnumerable<TList> val, string key, string message)
        {
            if (val == null)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a list contains no elements
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsEmpty<TList>(IEnumerable<TList> val, string key) =>
            IsEmpty(val, key, NotificationsErrorMessages.IsEmptyErrorMessage(key));

        /// <summary>
        /// Requires a list contains no elements
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsEmpty<TList>(IEnumerable<TList> val, string key, string message)
        {
            if (val.Any())
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a list contains at least one element
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsNotEmpty<TList>(IEnumerable<TList> val, string key) =>
            IsNotEmpty(val, key, NotificationsErrorMessages.IsNotEmptyErrorMessage(key));

        /// <summary>
        /// Requires a list contains at least one element
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsNotEmpty<TList>(IEnumerable<TList> val, string key, string message)
        {
            if (val.Any() == false)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a list count is greater than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterThan<TList>(IEnumerable<TList> val, int comparer, string key) =>
            IsGreaterThan(val, comparer, key, NotificationsErrorMessages.IsGreaterThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a list count is greater than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterThan<TList>(IEnumerable<TList> val, int comparer, string key, string message)
        {
            if (val?.Count() <= comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a list count is greater or equals than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterOrEqualsThan<TList>(IEnumerable<TList> val, int comparer, string key) =>
            IsGreaterOrEqualsThan(val, comparer, key, NotificationsErrorMessages.IsGreaterOrEqualsThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a list count is greater or equals than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsGreaterOrEqualsThan<TList>(IEnumerable<TList> val, int comparer, string key, string message)
        {
            if (val?.Count() < comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a list count is lower than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsLowerThan<TList>(IEnumerable<TList> val, int comparer, string key) =>
            IsLowerThan(val, comparer, key, NotificationsErrorMessages.IsLowerThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a list count is lower than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsLowerThan<TList>(IEnumerable<TList> val, int comparer, string key, string message)
        {
            if (val?.Count() >= comparer)
                AddNotification(key, message);

            return this;
        }

        /// <summary>
        /// Requires a list count is lower or equals than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsLowerOrEqualsThan<TList>(IEnumerable<TList> val, int comparer, string key) =>
            IsLowerOrEqualsThan(val, comparer, key, NotificationsErrorMessages.IsLowerOrEqualsThanErrorMessage(key, comparer.ToString()));

        /// <summary>
        /// Requires a list count is lower or equals than
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <param name="val"></param>
        /// <param name="comparer"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsLowerOrEqualsThan<TList>(IEnumerable<TList> val, int comparer, string key, string message)
        {
            if (val?.Count() > comparer)
                AddNotification(key, message);

            return this;
        }
    }
}
