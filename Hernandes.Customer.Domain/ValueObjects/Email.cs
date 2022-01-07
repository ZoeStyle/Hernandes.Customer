using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class Email :
        ValueObject
    {

        private string _address;
        public string Address { get => _address; }

        private Email() { }
        public Email(string address)
        {
            _address = address;
        }

        public override IResponse Validate()
        {
            AddNotifications(new Contract<string>()
                   .Requires()
                   .IsEmail(_address, nameof(_address), "this email is invalid")
                   .IsLowerOrEqualsThan(_address, 100, nameof(_address), "This field must contain a maximum of 100 characters")
                   );

            if (IsValid)
                return new ResponseOk<Email>(this, 1);

            return new ResponseError<Email>("400", "The email address was filled in incorrectly.", this.Notifications, this.Notifications.Count);
        }
    }
}
