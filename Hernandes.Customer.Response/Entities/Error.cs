using Hernandes.Customer.Notifications.Notifications;

namespace Hernandes.Customer.Response.Entities
{
    public class Error : Notifiable<Notification>
    {
        public Error(string code, string description, IReadOnlyCollection<Notification> data)
        {
            Code = code;
            Description = description;
            Data = data;
        }

        /// <summary>
        /// Error Code
        /// </summary>
        /// <example>400</example>
        public string Code { get; }

        /// <summary>
        /// Error Description
        /// </summary>
        /// <example>Bad Request</example>
        public string Description { get; }

        /// <summary>
        /// Error data
        /// </summary>
        public IReadOnlyCollection<Notification> Data { get; }

    }
}
