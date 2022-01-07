using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.ValueObjects;
using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.Entities
{
    public class Customer :
        Entity
    {
        private Document _document;
        private int _documentId;
        private Address _address;
        private int? _addressId;
        private PersonFis _personFis;
        private int? _personFisId;
        private PersonJur _personJur;
        private int? _personJurId;
        private List<Email> _emailList;
        private List<Phone> _phoneList;
        public Document Document { get => _document; }
        public int DocumentId { get => _documentId; }
        public PersonFis PersonFis { get => _personFis; }
        public int? PersonFisId { get => _personFisId; }
        public PersonJur PersonJur { get => _personJur; }
        public int? PersonJurId { get => _personJurId; }
        public Address Address { get => _address; }
        public int? AddressId { get => _addressId; }
        public IReadOnlyCollection<Phone> Phone => _phoneList.AsReadOnly();
        public IReadOnlyCollection<Email> EmailList => _emailList.AsReadOnly();

        private Customer() { }

        public Customer(Document document, Address address, PersonFis personFis)
        {
            _document = document;
            _documentId = document.Id;
            _address = address;
            _addressId = address != null ? address.Id : null;
            _personFis = personFis;
            _personFisId = personFis != null ? personFis.Id : null;
            _phoneList = new List<Phone>();
            _emailList = new List<Email>();
        }


        public Customer(Document document, Address address, PersonJur personJur)
        {
            _document = document;
            _documentId = document.Id;
            _address = address;
            _addressId = address != null ? address.Id : null;
            _personJur = personJur;
            _personJurId = personJur != null ? personJur.Id : null;
            _phoneList = new List<Phone>();
            _emailList = new List<Email>();
        }

        public IResponse UpdateCustomer(Document document, Address address, PersonFis personFis, List<Email> emailList, List<Phone> phoneList)
        {
            _document = document;
            _documentId = document.Id;
            _address = address;
            _addressId = address != null ? address.Id : null;
            _personFis = personFis;
            _personFisId = personFis != null ? personFis.Id : null;

            var validateEmail = CompareEmail(emailList);
            var validatePhone = ComparePhone(phoneList);
            var validateDocument = _document.Validate();
            var validateAddress = _address.Validate();
            var validatePerson = _personFis.Validate();

            if (validateEmail.HasError())
                AddNotifications(validateEmail.Error().Data);
            if (validatePhone.HasError())
                AddNotifications(validatePhone.Error().Data);
            if (validateDocument.HasError())
                AddNotifications(validateDocument.Error().Data);
            if (validateAddress.HasError())
                AddNotifications(validateAddress.Error().Data);
            if (validatePerson.HasError())
                AddNotifications(validatePerson.Error().Data);

            if (IsValid)
                return new ResponseOk<Customer>(this, 1);

            return new ResponseError<Customer>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
        }

        public IResponse UpdateCustomer(Document document, Address address, PersonJur personJur, Email emailList, List<Phone> phoneList)
        {
            _document = document;
            _documentId = document.Id;
            _address = address;
            _addressId = address != null ? address.Id : null;
            _personJur = personJur;
            _personJurId = personJur != null ? personJur.Id : null;

            var validateEmail = CompareEmail(emailList);
            var validatePhone = ComparePhone(phoneList);
            var validateDocument = _document.Validate();
            var validateAddress = _address.Validate();
            var validatePerson = _personJur.Validate();

            if (validateEmail.HasError())
                AddNotifications(validateEmail.Error().Data);
            if (validatePhone.HasError())
                AddNotifications(validatePhone.Error().Data);
            if (validateDocument.HasError())
                AddNotifications(validateDocument.Error().Data);
            if (validateAddress.HasError())
                AddNotifications(validateAddress.Error().Data);
            if (validatePerson.HasError())
                AddNotifications(validatePerson.Error().Data);

            if (IsValid)
                return new ResponseOk<Customer>(this, 1);

            return new ResponseError<Customer>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
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
                    AddNotifications(validateAddEmail.Error().Data);
            }

            if (IsValid)
                return new ResponseOk<List<Email>>(_emailList, _emailList.Count);

            return new ResponseError<List<Email>>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
        }

        private IResponse CompareEmail(Email email)
        {
            IResponse validateAddEmail = null;

            if (email == null)
                return new ResponseOk<List<Email>>(_emailList, 0);

            _emailList.Clear();


            validateAddEmail = AddEmail(email.Address);
            if (validateAddEmail.HasError())
                AddNotifications(validateAddEmail.Error().Data);

            if (IsValid)
                return new ResponseOk<List<Email>>(_emailList, _emailList.Count);

            return new ResponseError<List<Email>>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
        }

        private IResponse ComparePhone(List<Phone> phoneList)
        {
            IResponse validateAddPhone = null;

            if (phoneList == null)
                return new ResponseOk<List<Phone>>(_phoneList, 0);

            _phoneList.Clear();

            foreach (var phone in phoneList)
            {
                validateAddPhone = AddPhone(phone.Ddd, phone.PhoneNumber);
                if (validateAddPhone.HasError())
                    AddNotifications(validateAddPhone.Error().Data);
            }

            if (IsValid)
                return new ResponseOk<List<Phone>>(_phoneList, _phoneList.Count);

            return new ResponseError<List<Phone>>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
        }

        public IResponse AddPhone(string ddd, string newPhone)
        {
            var existPhone = _phoneList.AsQueryable().FirstOrDefault(x => x.PhoneNumber == newPhone && x.Ddd == ddd);

            if (existPhone != null)
            {
                AddNotification(nameof(newPhone), "Phone already exists.");
                return new ResponseError<List<Phone>>("400", "Phone already exists.", Notifications, Notifications.Count);
            }

            var phone = new Phone(ddd, newPhone);

            var validatePhone = phone.Validate();

            if (validatePhone.HasError())
                AddNotifications(validatePhone.Error().Data);

            if (!IsValid)
                return new ResponseError<List<Phone>>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);

            _phoneList.Add(phone);

            return new ResponseOk<List<Phone>>(_phoneList, _phoneList.Count);
        }

        public IResponse AddEmail(string address)
        {
            var existEmail = _emailList.AsQueryable().FirstOrDefault(x => x.Address == address);

            if (existEmail != null)
            {
                AddNotification(nameof(address), "Email already exists.");
                return new ResponseError<List<Email>>("400", "Email already exists.", Notifications, Notifications.Count);
            }

            var email = new Email(address);

            var validateEmail = email.Validate();

            if (validateEmail.HasError())
                AddNotifications(validateEmail.Error().Data);

            if (!IsValid)
                return new ResponseError<List<Email>>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);

            _emailList.Add(email);

            return new ResponseOk<List<Email>>(_emailList, _emailList.Count);
        }

        public override IResponse Validate()
        {
            IResponse validatePerson = null;
            IResponse validateDocument = null;
            if (PersonFis != null && Document.Type == DocumentType.Fisica)
            {
                validatePerson = PersonFis.Validate();
                validateDocument = Document.Validate();

                if (validateDocument.HasError())
                    AddNotifications(validateDocument.Error().Data);
                if (validatePerson.HasError())
                    AddNotifications(validatePerson.Error().Data);
            }
            else if (PersonJur != null && Document.Type == DocumentType.Juridica)
            {
                validatePerson = PersonJur.Validate();
                validateDocument = Document.Validate();

                if (validateDocument.HasError())
                    AddNotifications(validateDocument.Error().Data);
                if (validatePerson.HasError())
                    AddNotifications(validatePerson.Error().Data);
            }
            else
                AddNotification("Person", "It is necessary to inform one of the value objects (PersonFis or PersonJur).");

            if (Address != null)
            {
                var validateAddress = Address.Validate();

                if (validateAddress.HasError())
                    AddNotifications(validateAddress.Error().Data);
            }

            if (IsValid)
                return new ResponseOk<Customer>(this, 1);

            return new ResponseError<Customer>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
        }
    }
}
