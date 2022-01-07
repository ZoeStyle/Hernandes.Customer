using System;
using System.Collections.Generic;
using System.Linq;
using Hernandes.Customer.Notifications.Localization;

namespace Hernandes.Customer.Notifications.Validations
{
    public partial class Contract<T>
    {
        #region IsGreaterThan
        /// <summary>
        /// Requires a date is greater than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsGreaterThan(DateTime val, DateTime comparer, string key) =>
            IsGreaterThan(val, comparer, key, NotificationsErrorMessages.IsGreaterThanErrorMessage(key, comparer.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a date is greater than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Customer error message</param>
        /// <returns></returns>
        public Contract<T> IsGreaterThan(DateTime val, DateTime comparer, string key, string message)
        {
            if (val <= comparer)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsGreaterOrEqualsThan
        /// <summary>
        /// Requires a date is greater or equals than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsGreaterOrEqualsThan(DateTime val, DateTime comparer, string key) =>
            IsGreaterOrEqualsThan(val, comparer, key, NotificationsErrorMessages.IsGreaterOrEqualsThanErrorMessage(key, comparer.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a date is greater or equals than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsGreaterOrEqualsThan(DateTime val, DateTime comparer, string key, string message)
        {
            if (val < comparer)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsLowerThan
        /// <summary>
        /// Requires a date is lower than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsLowerThan(DateTime val, DateTime comparer, string key) =>
            IsLowerThan(val, comparer, key, NotificationsErrorMessages.IsLowerThanErrorMessage(key, comparer.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a date is lower than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Customer error message</param>
        /// <returns></returns>
        public Contract<T> IsLowerThan(DateTime val, DateTime comparer, string key, string message)
        {
            if (val >= comparer)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsLowerOrEqualsThan
        /// <summary>
        /// Requires a date is lower or equals than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsLowerOrEqualsThan(DateTime val, DateTime comparer, string key) =>
            IsLowerOrEqualsThan(val, comparer, key, NotificationsErrorMessages.IsLowerOrEqualsThanErrorMessage(key, comparer.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a date is lower or equals than
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="comparer">comparer</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsLowerOrEqualsThan(DateTime val, DateTime comparer, string key, string message)
        {
            if (val > comparer)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsNull
        /// <summary>
        /// Requires a date is null
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsNull(DateTime? val, string key) =>
            IsNull(val, key, NotificationsErrorMessages.IsNullErrorMessage(key));

        /// <summary>
        /// Requires a date is null
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsNull(DateTime? val, string key, string message)
        {
            if (val != null)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsNotNull
        /// <summary>
        /// Requires a date is not null
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsNotNull(DateTime? val, string key) =>
            IsNotNull(val, key, NotificationsErrorMessages.IsNotNullErrorMessage(key));

        /// <summary>
        /// Requires a date is not null
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsNotNull(DateTime? val, string key, string message)
        {
            if (val == null)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsBetween
        /// <summary>
        /// Requires a date is between
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsBetween(DateTime val, DateTime start, DateTime end, string key) =>
            IsBetween(val, start, end, key, NotificationsErrorMessages.IsBetweenErrorMessage(key, start.ToString(NotificationsFormats.DateTimeFormat), end.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a date is between
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Customer error message</param>
        /// <returns></returns>
        public Contract<T> IsBetween(DateTime val, DateTime start, DateTime end, string key, string message)
        {
            if ((val >= start && val <= end) == false)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsNotBetween
        /// <summary>
        /// Requires a date is not between
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsNotBetween(DateTime val, DateTime start, DateTime end, string key) =>
            IsNotBetween(val, start, end, key, NotificationsErrorMessages.IsNotBetweenErrorMessage(key, start.ToString(NotificationsFormats.DateTimeFormat), end.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a date is not between
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Customer error message</param>
        /// <returns></returns>
        public Contract<T> IsNotBetween(DateTime val, DateTime start, DateTime end, string key, string message)
        {
            if ((val >= start && val <= end) == true)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsMinValue
        /// <summary>
        /// Requires a date is min value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsMinValue(DateTime val, string key) =>
            IsMinValue(val, key, NotificationsErrorMessages.IsMinValueErrorMessage(key, DateTime.MinValue.ToString(NotificationsFormats.DateTimeFormat)));


        /// <summary>
        /// Requires a date is min value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsMinValue(DateTime val, string key, string message)
        {
            if (val != DateTime.MinValue)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsNotMinValue
        /// <summary>
        /// Requires a date is not min value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsNotMinValue(DateTime val, string key) =>
            IsNotMinValue(val, key, NotificationsErrorMessages.IsNotMinValueErrorMessage(key, DateTime.MinValue.ToString(NotificationsFormats.DateTimeFormat)));


        /// <summary>
        /// Requires a date is not min value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsNotMinValue(DateTime val, string key, string message)
        {
            if (val == DateTime.MinValue)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsMaxValue
        /// <summary>
        /// Requires a date is max value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsMaxValue(DateTime val, string key) =>
            IsMaxValue(val, key, NotificationsErrorMessages.IsMaxValueErrorMessage(key, DateTime.MaxValue.ToString(NotificationsFormats.DateTimeFormat)));


        /// <summary>
        /// Requires a date is max value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsMaxValue(DateTime val, string key, string message)
        {
            if (val != DateTime.MaxValue)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region IsNotMaxValue
        /// <summary>
        /// Requires a date is not max value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsNotMaxValue(DateTime val, string key) =>
            IsNotMaxValue(val, key, NotificationsErrorMessages.IsNotMaxValueErrorMessage(key, DateTime.MaxValue.ToString(NotificationsFormats.DateTimeFormat)));


        /// <summary>
        /// Requires a date is not max value
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsNotMaxValue(DateTime val, string key, string message)
        {
            if (val == DateTime.MaxValue)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region AreEquals

        /// <summary>
        /// Require dates are equals
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="comparer">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> AreEquals(DateTime val, DateTime comparer, string key)
            => AreEquals(val, comparer, key, NotificationsErrorMessages.AreEqualsErrorMessage(val.ToString(NotificationsFormats.DateTimeFormat), comparer.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Require dates are equals
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="comparer">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Customer error message</param>
        /// <returns></returns>
        public Contract<T> AreEquals(DateTime val, DateTime comparer, string key, string message)
        {
            if (val != comparer)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region AreNotEquals
        /// <summary>
        /// Requires two dates are not equals
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="comparer">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> AreNotEquals(DateTime val, DateTime comparer, string key)
            => AreNotEquals(val, comparer, key, NotificationsErrorMessages.AreNotEqualsErrorMessage(val.ToString(NotificationsFormats.DateTimeFormat), comparer.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires two dates are not equals
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="comparer">date</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> AreNotEquals(DateTime val, DateTime comparer, string key, string message)
        {
            if (val == comparer)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region Contains
        /// <summary>
        /// Requires a list contains a date
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="list">list of dates</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> Contains(DateTime val, IEnumerable<DateTime> list, string key)
            => Contains(val, list, key, NotificationsErrorMessages.ContainsErrorMessage(key, val.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a list contains a date
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="list">list of dates</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> Contains(DateTime val, IEnumerable<DateTime> list, string key, string message)
        {
            if (list.Any(x => x == val) == false)
                AddNotification(key, message);

            return this;
        }
        #endregion

        #region NotContains
        /// <summary>
        /// Requires a list not contains a date
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="list">list of dates</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> NotContains(DateTime val, IEnumerable<DateTime> list, string key)
            => NotContains(val, list, key, NotificationsErrorMessages.NotContainsErrorMessage(key, val.ToString(NotificationsFormats.DateTimeFormat)));

        /// <summary>
        /// Requires a list not contains a date
        /// </summary>
        /// <param name="val">date</param>
        /// <param name="list">list of dates</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> NotContains(DateTime val, IEnumerable<DateTime> list, string key, string message)
        {
            if (list.Any(x => x == val) == true)
                AddNotification(key, message);

            return this;
        }
        #endregion
    }
}
