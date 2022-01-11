using Hernandes.Customer.Application.Commands;
using Hernandes.Customer.Application.DTOs;
using Hernandes.Customer.Application.Handlers.Contracts;
using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.ValueObjects;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Application.Handlers
{
    public partial class CustomerHandler
        : IHandler<CreateCustomerPersonFisCommand>,
        IHandler<UpdateCustomerPersonFisCommand>
    {
        public async Task<IResponse> Handle(CreateCustomerPersonFisCommand request)
        {
            //Fast validation
            var validateRequest = request.Validate();
            if (validateRequest.HasError())
                return validateRequest;

            // Enum
            var gender = GetByGender(request.Gender);

            //VOs
            var document = new Document
                (request.Cpf, DocumentType.Fisica);
            var address = new Address
                (request.Street, request.City, request.State, request.Country, request.ZipCode, request.Number);
            var person = new PersonFis
                (request.Name, gender, request.BirthDay, request.Rg);

            //Entity
            var customer = new Domain.Entities.Customer
                (document, address, person);

            // Validates that all data were filled in correctly
            var validateCustomer = customer.Validate();
            if (validateCustomer.HasError())
                return validateCustomer;

            // Scan email list to add in client
            foreach (EmailDTO email in request.EmailList)
            {
                var validateEmail = customer.AddEmail(email.Address);
                if (validateEmail.HasError())
                    AddNotifications(validateEmail.Error().Data);
            }

            // Validates if there was any error when adding email in the client entity
            if (!IsValid)
                return new ResponseError<Domain.Entities.Customer>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);

            // Scan phone list to add in client
            foreach (PhoneDTO phone in request.PhoneList)
            {
                var validatePhone = customer.AddPhone(phone.Ddd, phone.Number);
                if (validatePhone.HasError())
                    AddNotifications(validatePhone.Error().Data);
            }

            // Validates if there was any error when adding phone in the client entity
            if (!IsValid)
                return new ResponseError<Domain.Entities.Customer>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);

            // Add customer entity to data repository
            var validateRepository = await _repository.Add(customer);

            // Validates if there was an error executing the operation
            if (validateRepository.HasError())
                return validateRepository;

            return new ResponseOk<Domain.Entities.Customer>(customer);
        }

        public async Task<IResponse> Handle(UpdateCustomerPersonFisCommand request)
        {
            //Fast validation
            var validateRequest = request.Validate();
            if (validateRequest.HasError())
                return validateRequest;

            // Find the customer to be changed
            var validateFindCustomer = await _repository.GetByIdAsync(request.Id);

            // Validates if you brought data
            if (validateFindCustomer.HasError())
                return validateFindCustomer;

            // Converts to a new customer entity
            var customer = (Domain.Entities.Customer)validateFindCustomer.ResponseObj();

            // Enum
            var gender = GetByGender(request.Gender);

            //VOs
            var document = new Document
                (request.Cpf, DocumentType.Fisica);
            var address = new Address
                (request.Street, request.City, request.State, request.Country, request.ZipCode, request.Number);
            var person = new PersonFis
                (request.Name, gender, request.BirthDay, request.Rg);

            // Create new email and phone lists
            var listEmail = new List<Email>();
            var listPhone = new List<Phone>();

            // Populates New Email and Phone Lists
            foreach (EmailDTO email in request.EmailList)
                listEmail.Add(new Email(email.Address));

            foreach (PhoneDTO phone in request.PhoneList)
                listPhone.Add(new Phone(phone.Ddd, phone.Number));

            // Update customer data
            var validateUpdate = customer.UpdateCustomer(document, address, person, listEmail, listPhone);

            // Validates if the update was successful
            if (validateUpdate.HasError())
                return validateUpdate;

            // Add customer entity to data repository
            var validateRepository = await _repository.Update(customer);

            // Validates if there was an error executing the operation
            if (validateRepository.HasError())
                return validateRepository;

            return new ResponseOk<Domain.Entities.Customer>(customer);
        }

        private Gender GetByGender(int id)
        {
            switch (id)
            {
                case 1:
                    return Gender.Feminino;
                case 2:
                    return Gender.Masculino;
                default:
                    return Gender.Outros;
            }
        }
    }
}
