using Hernandes.Customer.Application.Commands.Contracts;
using Hernandes.Customer.Application.DTOs;
using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Application.Commands
{
    public class UpdateCustomerPersonJurCommand
        : Notifiable<Notification>, ICommand
    {
        public UpdateCustomerPersonJurCommand()
        {
            PhoneList = new List<PhoneDTO>();
        }

        public UpdateCustomerPersonJurCommand(string id, string cnpj, string corporateName, string fantasyName, string street, string city, string state, string country, string zipCode, string number, string email, List<PhoneDTO> phoneList)
        {
            Id = id;
            Cnpj = cnpj;
            CorporateName = corporateName;
            FantasyName = fantasyName;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Number = number;
            Email = email;
            PhoneList = phoneList != null ? phoneList : new List<PhoneDTO>();
        }

        /// <summary>
        /// Id do cliente
        /// </summary>
        /// <example>1</example>
        public string Id { get; set; }

        /// <summary>
        /// Numero do cnpj
        /// </summary>
        /// <example>89.407.257/0001-76</example>
        public string Cnpj { get; set; }

        /// <summary>
        /// Nome da empresa
        /// </summary>
        /// <example>Marcos e Bento Lavanderia Ltda</example>
        public string CorporateName { get; set; }

        /// <summary>
        /// Nome fantasia
        /// </summary>
        /// <example>Marcos e Bento Lavanderia Ltda</example>
        public string FantasyName { get; set; }

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

        /// <summary>
        /// Email do cliente
        /// </summary>
        /// <example>marcosviniciusthiagoramos@truckeixo.com.br</example>
        public string Email { get; set; }

        public List<PhoneDTO> PhoneList { get; set; }

        public IResponse Validate()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsNotNullOrEmpty(Id, nameof(Id), "This property is mandatory")
                .IsNotNullOrEmpty(CorporateName, nameof(CorporateName), "This property is mandatory")
                .IsNotNullOrEmpty(Cnpj, nameof(Cnpj), "This property is mandatory")
                .IsCNPJ(Cnpj, nameof(Cnpj), "The document entered must contain 18 characters")
                .IsLowerOrEqualsThan(CorporateName, 60, nameof(CorporateName), "The inserted document must contain a maximum of 60 characters")
                .IsLowerOrEqualsThan(FantasyName, 60, nameof(FantasyName), "The inserted document must contain a maximum of 60 characters")
                .IsLowerOrEqualsThan(Street, 60, nameof(Street), "This field must contain a maximum of 60 characters")
                .IsLowerOrEqualsThan(City, 60, nameof(City), "This field must contain a maximum of 60 characters")
                .IsLowerOrEqualsThan(State, 2, nameof(State), "This field must contain a maximum of 2 characters")
                .IsLowerOrEqualsThan(Country, 2, nameof(Country), "This field must contain a maximum of 2 characters")
                .IsLowerOrEqualsThan(ZipCode, 9, nameof(ZipCode), "This field must contain a maximum of 9 characters")
                .IsLowerOrEqualsThan(Number, 5, nameof(Number), "This field must contain a maximum of 5 characters")
                );

            if (Email != null)
            {
                AddNotifications(new Contract<string>()
                    .Requires()
                    .IsEmail(Email, nameof(Email))
                    .IsLowerOrEqualsThan(Email, 100, nameof(Email), "This field must contain a maximum of 100 characters")
                    );
            }

            if (PhoneList.Count > 0)
            {
                foreach (var phone in PhoneList)
                {
                    AddNotifications(new Contract<string>()
                    .Requires()
                    .IsLowerOrEqualsThan(phone.Ddd, 2, nameof(phone.Ddd), "This field must contain a maximum of 2 characters")
                    .IsLowerOrEqualsThan(phone.Number, 10, nameof(phone.Number), "This field must contain a maximum of 13 characters")
                    );
                }
            }

            if (IsValid)
                return new ResponseOk<UpdateCustomerPersonJurCommand>(this, 1);

            return new ResponseError<UpdateCustomerPersonJurCommand>("400", "The data for updating the customer is incorrect.", Notifications, Notifications.Count);
        }
    }
}
