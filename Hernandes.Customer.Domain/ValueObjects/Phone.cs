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
        public string DDD { get => _ddd; }
        public string PhoneNumber { get => _phoneNumber; }

        public Phone(string ddd, string phoneNumber)
        {
            _ddd = ddd;
            _phoneNumber = phoneNumber;
        }
    }
}
