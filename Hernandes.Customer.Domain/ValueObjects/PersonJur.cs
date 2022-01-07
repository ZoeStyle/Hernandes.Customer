using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class PersonJur
        : ValueObject
    {
        private string _corporateName;
        private string _fantasyName;

        public string CorporateName { get => _corporateName; }
        public string FantasyName { get => _fantasyName; }
        //public Customer Customer { get; }

        private PersonJur() { }
        public PersonJur(string corporateName, string fantasyName)
        {
            _corporateName = corporateName;
            _fantasyName = fantasyName;
        }

        public override IResponse Validate()
        {
            AddNotifications(new Contract<string>()
                    .Requires()
                    .IsLowerOrEqualsThan(_corporateName, 60, nameof(_corporateName), "The inserted document must contain a maximum of 60 characters")
                    .IsNotNullOrEmpty(_corporateName, nameof(_corporateName), "This property is mandatory")
                    .IsLowerOrEqualsThan(_fantasyName, 60, nameof(_fantasyName), "The inserted document must contain a maximum of 60 characters")
                    );

            if (IsValid)
                return new ResponseOk<PersonJur>(this, 1);

            return new ResponseError<PersonJur>("400", "The registered Legal person is filled in incorrectly.", this.Notifications, this.Notifications.Count);
        }
    }
}
