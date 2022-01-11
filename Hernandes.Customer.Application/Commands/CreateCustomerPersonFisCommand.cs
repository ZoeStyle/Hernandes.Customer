using Hernandes.Customer.Application.Commands.Contracts;
using Hernandes.Customer.Application.DTOs;
using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Application.Commands
{
    public class CreateCustomerPersonFisCommand
        : Notifiable<Notification>, ICommand
    {
        public CreateCustomerPersonFisCommand()
        {
            EmailList = new List<EmailDTO>();
            PhoneList = new List<PhoneDTO>();
        }

        public CreateCustomerPersonFisCommand(string cpf, string name, int gender, DateTime? birthDay, string rg, string street, string city, string state, string country, string zipCode, string number, List<EmailDTO> emailList, List<PhoneDTO> phoneList)
        {
            Cpf = cpf;
            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Rg = rg;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Number = number;
            EmailList = emailList != null ? emailList : new List<EmailDTO>();
            PhoneList = phoneList != null ? phoneList : new List<PhoneDTO>();
        }

        /// <summary>
        /// Numero do documento
        /// </summary>
        /// <example>427.487.569-59</example>
        public string Cpf { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        /// <example>Miguel Ruan Alves</example>
        public string Name { get; set; }

        /// <summary>
        /// Genero do cliente
        /// </summary>
        /// <example>1</example>
        public int Gender { get; set; }

        /// <summary>
        /// Data de aniversário
        /// </summary>
        /// <example>1947-09-10</example>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// Numero do rg
        /// </summary>
        /// <example>19.100.253-7</example>
        public string Rg { get; set; }
        /// <summary>
        /// Rua
        /// </summary>
        /// <example>Quadra SOFN Quadra 4 Bloco B</example>
        public string Street { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        /// <example>Brasília</example>
        public string City { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        /// <example>DF</example>
        public string State { get; set; }

        /// <summary>
        /// País
        /// </summary>
        /// <example>BR</example>
        public string Country { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        /// <example>70634-467</example>
        public string ZipCode { get; set; }

        /// <summary>
        /// Numero
        /// </summary>
        /// <example>6</example>
        public string Number { get; set; }

        public List<EmailDTO> EmailList { get; set; }
        public List<PhoneDTO> PhoneList { get; set; }

        public IResponse Validate()
        {
            AddNotifications(new Contract<string>()
            .Requires()
            .IsNotNullOrEmpty(Name, nameof(Name), "This property is mandatory")
            .IsNotNullOrEmpty(Cpf, nameof(Cpf), "This property is mandatory")
            .IsCPF(Cpf, nameof(Cpf), "The document entered must contain 14 characters")
            .IsLowerOrEqualsThan(Name, 60, nameof(Name), "The inserted document must contain a maximum of 60 characters")
            .IsRG(Rg, nameof(Rg), "The inserted document must contain a maximum of 12 characters")
            .IsLowerOrEqualsThan(Street, 60, nameof(Street), "This field must contain a maximum of 60 characters")
            .IsLowerOrEqualsThan(City, 60, nameof(City), "This field must contain a maximum of 60 characters")
            .IsLowerOrEqualsThan(State, 2, nameof(State), "This field must contain a maximum of 2 characters")
            .IsLowerOrEqualsThan(Country, 2, nameof(Country), "This field must contain a maximum of 2 characters")
            .IsLowerOrEqualsThan(ZipCode, 9, nameof(ZipCode), "This field must contain a maximum of 9 characters")
            .IsLowerOrEqualsThan(Number, 5, nameof(Number), "This field must contain a maximum of 5 characters")
            .IsLowerThan(Gender, 4, nameof(Gender), "Inform the following codes for genders 1 - Female, 2 - Male and 3 - Other")
            .IsGreaterThan(Gender, 0, nameof(Gender), "Inform the following codes for genders 1 - Female, 2 - Male and 3 - Other")
            );

            if (BirthDay != null)
            {
                var date = BirthDay ?? DateTime.Now;
                AddNotifications(new Contract<string>()
                    .Requires()
                    .IsLowerThan(date, DateTime.Now, nameof(BirthDay), "The date entered cannot be greater than today")
                    );
            }

            if (EmailList.Count > 0)
            {
                foreach (var email in EmailList)
                {
                    AddNotifications(new Contract<string>()
                    .Requires()
                    .IsEmail(email.Address, nameof(email))
                    .IsLowerOrEqualsThan(email.Address, 100, nameof(email), "This field must contain a maximum of 100 characters")
                    );
                }
            }

            if (PhoneList.Count > 0)
            {
                foreach (var phone in PhoneList)
                {
                    AddNotifications(new Contract<string>()
                    .Requires()
                    .IsLowerOrEqualsThan(phone.Ddd, 2, nameof(phone.Ddd), "This field must contain a maximum of 2 characters")
                    .IsLowerOrEqualsThan(phone.Number, 10, nameof(phone.Number), "This field must contain a maximum of 10 characters")
                    );
                }
            }

            if (IsValid)
                return new ResponseOk<CreateCustomerPersonFisCommand>(this, 1);

            return new ResponseError<CreateCustomerPersonFisCommand>("400", "The data for insert the customer is incorrect.", Notifications, Notifications.Count);
        }
    }
}
