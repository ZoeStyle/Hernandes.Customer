using Hernandes.Customer.Notifications.Localization;

namespace Hernandes.Customer.Notifications.Validations
{
    public partial class Contract<T>
    {
        #region Passport
        /// <summary>
        /// Requires a string is a passport number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsPassport(string val, string key) =>
            IsPassport(val, key, NotificationsErrorMessages.IsPassportErrorMessage(key));

        /// <summary>
        /// Requires a string is a passport number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsPassport(string val, string key, string message) =>
            Matches(val, NotificationsRegexPatterns.PassportRegexPattern, key, message);
        #endregion

        #region CPF
        /// <summary>
        /// Requires a string is a CPF number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsCPF(string val, string key) =>
            IsCPF(val, key, NotificationsErrorMessages.IsCPFErrorMessage(key));

        /// <summary>
        /// Requires a string is a CPF number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsCPF(string val, string key, string message) =>
            Matches(val, NotificationsRegexPatterns.CPFRegexPattern, key, message);
        #endregion

        #region CNPJ
        /// <summary>
        /// Requires a string is a CNPJ number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsCNPJ(string val, string key) =>
            IsCNPJ(val, key, NotificationsErrorMessages.IsCNPJErrorMessage(key));

        /// <summary>
        /// Requires a string is a CNPJ number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsCNPJ(string val, string key, string message) =>
            Matches(val, NotificationsRegexPatterns.CNPJRegexPattern, key, message);
        #endregion

        #region RG
        /// <summary>
        /// Requires a string is a RG number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <returns></returns>
        public Contract<T> IsRG(string val, string key) =>
            IsRG(val, key, NotificationsErrorMessages.IsRGErrorMessage(key));

        /// <summary>
        /// Requires a string is a RG number
        /// </summary>
        /// <param name="val">val</param>
        /// <param name="key">Key or Property Name</param>
        /// <param name="message">Custom error message</param>
        /// <returns></returns>
        public Contract<T> IsRG(string val, string key, string message) =>
            Matches(val, NotificationsRegexPatterns.RGRegexPattern, key, message);
        #endregion
    }
}
