using Hernandes.Customer.Domain.Services;
using Hernandes.Customer.Domain.ValueObjects;
using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.Entities
{
    public class Customer :
        Entity
    {
        private NotificationsService _notification;
        private Document _document;
        private Address _address;
        private PersonFis _personFis;
        private PersonJur _personJur;
        private List<Email> _emailList;
        private List<Phone> _phoneList;
        public Document Document { get => _document; }
        public PersonFis PersonFis { get => _personFis; }
        public PersonJur PersonJur { get => _personJur; }
        public Address Address { get => _address; }
        public IReadOnlyCollection<Phone> Phone => _phoneList.AsReadOnly();
        public IReadOnlyCollection<Email> EmailList => _emailList.AsReadOnly();

        public Customer(Document document, Address address, PersonFis personFis, PersonJur personJur)
        {
            _document = document;
            _address = address;
            _personFis = personFis;
            _personJur = personJur;
            _phoneList = new List<Phone>();
            _emailList = new List<Email>();
            _notification = new NotificationsService();
        }

        public Customer(Document document, Address address, PersonFis personFis)
        {
            _document = document;
            _address = address;
            _personFis = personFis;
            _phoneList = new List<Phone>();
            _emailList = new List<Email>();
            _notification = new NotificationsService();
        }

        public Customer(Document document, Address address, PersonJur personJur)
        {
            _document = document;
            _address = address;
            _personJur = personJur;
            _phoneList = new List<Phone>();
            _emailList = new List<Email>();
            _notification = new NotificationsService();
        }

        public IResponse UpdateCustomer(Document document, Address address, PersonFis personFis, List<Email> emailList, List<Phone> phoneList)
        {
            _document = document;
            _address = address;
            _personFis = personFis;

            var listResult = new List<string>();
            var validateEmail = CompareEmail(emailList);
            var validatePhone = ComparePhone(phoneList);
            var validate = _notification.Validate(this);

            if (validateEmail.HasError())
            {
                var result = _notification.ConvertNotifications(validateEmail.Error().Data);
                listResult.Add(result);
            }
            if (validatePhone.HasError())
            {
                var result = _notification.ConvertNotifications(validatePhone.Error().Data);
                listResult.Add(result);
            }
            if (validate.HasError())
            {
                var result = _notification.ConvertNotifications(validate.Error().Data);
                listResult.Add(result);
            }

            if (listResult.Count == 0)
                return new ResponseOk<Customer>(this, 1);

            var response = _notification.Notification("Error", "The data for updating the customer is incorrect.", listResult, "400");

            return response;
        }

        public IResponse UpdateCustomer(Document document, Address address, PersonJur personJur, Email emailList, List<Phone> phoneList)
        {
            _document = document;
            _address = address;
            _personJur = personJur;

            var listResult = new List<string>();
            var validateEmail = CompareEmail(emailList);
            var validatePhone = ComparePhone(phoneList);
            var validate = _notification.Validate(this);

            if (validateEmail.HasError())
            {
                var result = _notification.ConvertNotifications(validateEmail.Error().Data);
                listResult.Add(result);
            }
            if (validatePhone.HasError())
            {
                var result = _notification.ConvertNotifications(validatePhone.Error().Data);
                listResult.Add(result);
            }
            if(validate.HasError())
            {
                var result = _notification.ConvertNotifications(validate.Error().Data);
                listResult.Add(result);
            }

            if(listResult.Count == 0)
                return new ResponseOk<Customer>(this, 1);

            var response = _notification.Notification("Error", "The data for updating the customer is incorrect.", listResult, "400");

            return response;
        }

        private IResponse CompareEmail(List<Email> emailList)
        {
            IResponse validateAddEmail = null;

            if (emailList == null)
                return new ResponseOk<List<Email>>(_emailList, 0);

            _emailList.Clear();

            foreach (var email in emailList)
            {
                validateAddEmail = AddEmail(email.Address);
                if (validateAddEmail.HasError())
                    return validateAddEmail;
            }
        
            return new ResponseOk<List<Email>>(_emailList, _emailList.Count);
        }

        private IResponse CompareEmail(Email email)
        {
            IResponse validateAddEmail = null;

            if (email == null)
                return new ResponseOk<List<Email>>(_emailList, 0);

            _emailList.Clear();


            validateAddEmail = AddEmail(email.Address);
            if (validateAddEmail.HasError())
                return validateAddEmail;
        
            return new ResponseOk<List<Email>>(_emailList, _emailList.Count);
        }

        private IResponse ComparePhone(List<Phone> phoneList)
        {
            IResponse validateAddPhone = null;

            if (phoneList == null)
                return new ResponseOk<List<Phone>>(_phoneList, 0);

            _phoneList.Clear();

            foreach (var phone in phoneList)
            {
                validateAddPhone = AddPhone(phone.DDD, phone.PhoneNumber);
                if (validateAddPhone.HasError())
                    return validateAddPhone;
            }

            return new ResponseOk<List<Phone>>(_phoneList, _phoneList.Count);
        }

        public IResponse AddPhone(string ddd, string newPhone)
        {
            var existPhone = _phoneList.AsQueryable().FirstOrDefault(x => x.PhoneNumber == newPhone && x.DDD == ddd);

            if (existPhone != null)
                return _notification.Notification(nameof(newPhone), "Phone already exists.", "400");

            var phone = new Phone(ddd, newPhone);

            var validatePhone = _notification.Validate(phone);

            if (validatePhone.HasError())
                return validatePhone;

            _phoneList.Add(phone);

            return new ResponseOk<List<Phone>>(_phoneList, _phoneList.Count);
        }

        public IResponse AddEmail(string address)
        {
            if(string.IsNullOrEmpty(address))
                return _notification.Notification(nameof(address), "Mandatory parameter", "400");

            var existEmail = _emailList.AsQueryable().FirstOrDefault(x => x.Address == address);

            if (existEmail != null)
                return _notification.Notification(nameof(address), "Email already exists.", "400");

            var email = new Email(address);

            var validateEmail = _notification.Validate(email);

            if (validateEmail.HasError())
                return validateEmail;

            _emailList.Add(email);

            return new ResponseOk<List<Email>>(_emailList, _emailList.Count);
        }

        public override IResponse Validate()
        {
            var response = _notification.Validate(this);
            return response;
        }

    }
}
