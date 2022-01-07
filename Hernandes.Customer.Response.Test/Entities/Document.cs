using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Response.Test.Entities
{
    public class Document : Notifiable<Notification>
    {
        public Document(string number)
        {
            Number = number;
        }

        /// <summary>
        /// Document number
        /// </summary>
        public string Number { get; }

        public IResponse Validate() 
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsCPF(Number,nameof(Number))
                );

            if(IsValid)
                return new ResponseOk<Document>(this);

            return new ResponseError<Document>("400", "Custom error message", this.Notifications, this.Notifications.Count);
        }
    }
}
