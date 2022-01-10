using Hernandes.Customer.Domain.Work;

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
    }
}
