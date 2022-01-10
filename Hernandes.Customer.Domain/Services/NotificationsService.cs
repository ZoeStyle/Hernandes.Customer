using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hernandes.Customer.Domain.Services
{
    public class NotificationsService : Notifiable<Notification>
    {
        public IResponse Notification(string val, string message, string error)
        {
            AddNotification(val, message);
            return new ResponseError<bool>(error, message, Notifications, Notifications.Count);
        }

        public IResponse Notification(string val, string message, List<string> errorMessage, string error)
        {
            AddNotification(val, errorMessage);
            return new ResponseError<bool>(error, message, Notifications, Notifications.Count);
        }

        public string ConvertNotifications(IReadOnlyCollection<Notification> notifications)
        {
            string result = string.Empty;
            foreach (var message in notifications)
                result += message.ToString() + ",";

            result = result.Remove(result.Length - 1);

            return result;
        }

        public IResponse Validate(Entities.Customer value)
        {
            IResponse validatePerson = null;
            IResponse validateDocument = null;
            if (value.PersonFis != null && value.Document.Type == Enums.DocumentType.Fisica)
            {
                Validate(value.PersonFis);
                Validate(value.Document);
            }
            else if (value.PersonJur != null && value.Document.Type == Enums.DocumentType.Juridica)
            {
                Validate(value.PersonJur);
                Validate(value.Document);
            }
            else
                AddNotification("Person", "It is necessary to inform one of the value objects (PersonFis or PersonJur).");

            if (value.Address != null)
            {
                Validate(value.Address);
            }

            if (IsValid)
                return new ResponseOk<Entities.Customer>(value, 1);

            return new ResponseError<Entities.Customer>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
        }

        private void Validate(ValueObjects.Address value)
        {
            AddNotifications(new Contract<string>()
                        .Requires()
                        .IsLowerOrEqualsThan(value.Street, 60, nameof(value.Street), "This field must contain a maximum of 60 characters")
                        .IsLowerOrEqualsThan(value.City, 60, nameof(value.City), "This field must contain a maximum of 60 characters")
                        .IsLowerOrEqualsThan(value.State, 2, nameof(value.State), "This field must contain a maximum of 2 characters")
                        .IsLowerOrEqualsThan(value.Country, 2, nameof(value.Country), "This field must contain a maximum of 2 characters")
                        .IsLowerOrEqualsThan(value.ZipCode, 9, nameof(value.ZipCode), "This field must contain a maximum of 9 characters")
                        .IsLowerOrEqualsThan(value.Number, 5, nameof(value.Number), "This field must contain a maximum of 5 characters")
                        );
        }

        private void Validate(ValueObjects.Document value)
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsNotNullOrEmpty(value.DocumentNumber, nameof(value.DocumentNumber), "The document number cannot be null.")
                .IsNotNull(value.Type, nameof(value.Type), "The type of document entered cannot be null.")
                );

            switch (value.Type.Id)
            {
                case 1:
                    AddNotifications(new Contract<string>()
                        .Requires()
                        .IsCNPJ(value.DocumentNumber, nameof(value.DocumentNumber), "The document entered is incorrect.")
                        );
                    break;
                case 2:
                    AddNotifications(new Contract<string>()
                        .Requires()
                        .IsCPF(value.DocumentNumber, nameof(value.DocumentNumber), "The document entered is incorrect.")
                        );
                    break;
            }
        }

        public IResponse Validate(ValueObjects.Email value)
        {
            AddNotifications(new Contract<string>()
                   .Requires()
                   .IsEmail(value.Address, nameof(value.Address), "this email is invalid")
                   .IsLowerOrEqualsThan(value.Address, 100, nameof(value.Address), "This field must contain a maximum of 100 characters")
                   );

            if (IsValid)
                return new ResponseOk<ValueObjects.Email>(value, 1);

            return new ResponseError<ValueObjects.Email>("400", "The email address was filled in incorrectly.", this.Notifications, this.Notifications.Count);
        }

        private void Validate(ValueObjects.PersonFis value)
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsLowerOrEqualsThan(value.Name, 60, nameof(value.Name), "The inserted document must contain a maximum of 60 characters")
                .IsNotNullOrEmpty(value.Name, nameof(value.Name), "This property is mandatory")
                .IsRG(value.Rg, nameof(value.Rg), "The inserted document must contain a maximum of 12 characters")
                );

            if (value.BirthDay != null)
            {
                var date = value.BirthDay ?? DateTime.Now;
                AddNotifications(new Contract<string>()
                .Requires()
                .IsLowerThan(date, DateTime.Now, nameof(value.BirthDay), "The date entered cannot be greater than today")
                );
            }
        }

        private void Validate(ValueObjects.PersonJur value)
        {
            AddNotifications(new Contract<string>()
                    .Requires()
                    .IsLowerOrEqualsThan(value.CorporateName, 60, nameof(value.CorporateName), "The inserted document must contain a maximum of 60 characters")
                    .IsNotNullOrEmpty(value.CorporateName, nameof(value.CorporateName), "This property is mandatory")
                    .IsLowerOrEqualsThan(value.FantasyName, 60, nameof(value.FantasyName), "The inserted document must contain a maximum of 60 characters")
                    );
        }

        public IResponse Validate(ValueObjects.Phone value)
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsLowerOrEqualsThan(value.DDD, 2, nameof(value.DDD), "This field must contain a maximum of 2 characters")
                .IsLowerOrEqualsThan(value.PhoneNumber, 10, nameof(value.PhoneNumber), "This field must contain a maximum of 10 characters")
                );

            if (IsValid)
                return new ResponseOk<ValueObjects.Phone>(value, 1);

            return new ResponseError<ValueObjects.Phone>("400", "The phone number informed is incorrect.", this.Notifications, this.Notifications.Count);
        }
    }
}
