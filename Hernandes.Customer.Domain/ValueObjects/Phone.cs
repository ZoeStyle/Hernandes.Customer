using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class Phone :
        ValueObject
    {
        private string _ddd;
        private string _phoneNumber;
        public string Ddd { get => _ddd; }
        public string PhoneNumber { get => _phoneNumber; }

        private Phone() { }

        public Phone(string ddd, string phoneNumber)
        {
            _ddd = ddd;
            _phoneNumber = phoneNumber;
        }

        public override IResponse Validate()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsLowerOrEqualsThan(_ddd, 2, nameof(_phoneNumber), "This field must contain a maximum of 2 characters")
                .IsLowerOrEqualsThan(_phoneNumber, 10, nameof(_phoneNumber), "This field must contain a maximum of 10 characters")
                );

            if (IsValid)
                return new ResponseOk<Phone>(this, 1);

            return new ResponseError<Phone>("400", "The phone number informed is incorrect.", this.Notifications, this.Notifications.Count);

        }
    }
}
