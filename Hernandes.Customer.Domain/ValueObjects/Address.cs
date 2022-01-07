using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class Address :
        ValueObject
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;
        private string _zipCode;
        private string _number;

        //public Customer Customer { get; }
        public string Street { get => _street; }
        public string City { get => _city; }
        public string State { get => _state; }
        public string Country { get => _country; }
        public string ZipCode { get => _zipCode; }
        public string Number { get => _number; }

        private Address() { }

        public Address(string street, string city, string state, string country, string zipCode, string number)
        {
            _street = street;
            _city = city;
            _state = state;
            _country = country;
            _zipCode = zipCode;
            _number = number;
        }


        public override IResponse Validate()
        {
            AddNotifications(new Contract<string>()
                        .Requires()
                        .IsLowerOrEqualsThan(_street, 60, nameof(_street), "This field must contain a maximum of 60 characters")
                        .IsLowerOrEqualsThan(_city, 60, nameof(_city), "This field must contain a maximum of 60 characters")
                        .IsLowerOrEqualsThan(_state, 2, nameof(_state), "This field must contain a maximum of 2 characters")
                        .IsLowerOrEqualsThan(_country, 2, nameof(_country), "This field must contain a maximum of 2 characters")
                        .IsLowerOrEqualsThan(_zipCode, 9, nameof(_zipCode), "This field must contain a maximum of 9 characters")
                        .IsLowerOrEqualsThan(_number, 5, nameof(_number), "This field must contain a maximum of 5 characters")
                        );

            if (IsValid)
                return new ResponseOk<Address>(this, 1);

            return new ResponseError<Address>("400", "The address was filled out incorrectly.", this.Notifications, this.Notifications.Count);
        }
    }
}
