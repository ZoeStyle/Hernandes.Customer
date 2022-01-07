﻿using System.Linq;
using System.Text.RegularExpressions;
using Hernandes.Customer.Notifications.Localization;

namespace Hernandes.Customer.Notifications.Validations
{
    public partial class Contract<T>
    {
        /// <summary>
        /// Requires a string is a Credit Card number
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contract<T> IsCreditCard(string val, string key) =>
            IsCreditCard(val, key, NotificationsErrorMessages.IsCreditCardErrorMessage(key));

        /// <summary>
        /// Requires a string is a Credit Card number
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Contract<T> IsCreditCard(string val, string key, string message)
        {
            val = Regex.Replace(val, NotificationsRegexPatterns.OnlyNumbersPattern, "");

            if (string.IsNullOrWhiteSpace(val))
            {
                AddNotification(key, message);
                return this;
            }

            var even = false;
            var checksum = 0;

            foreach (var digit in val.ToCharArray().Reverse())
            {
                if (!char.IsDigit(digit))
                {
                    AddNotification(val, message);
                    return this;
                }

                var value = (digit - '0') * (even ? 2 : 1);
                even = !even;

                while (value > 0)
                {
                    checksum += value % 10;
                    value /= 10;
                }
            }

            if (checksum % 10 != 0)
                AddNotification(key, message);

            return this;
        }
    }
}
