using Hernandes.Customer.Domain.Work;

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
    }
}
