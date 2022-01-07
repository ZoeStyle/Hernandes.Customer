using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class PersonFis
        : ValueObject
    {
        private string _name;
        private Gender _gender;
        private int _genderId;
        private DateTime? _birthDay;
        private string _rg;

        //public Customer Customer { get; }
        public string Name { get => _name; }
        public Gender Gender { get => _gender; }
        public int GenderId { get => _genderId; }
        public DateTime? BirthDay { get => _birthDay; }
        public string Rg { get => _rg; }

        private PersonFis() { }
        public PersonFis(string name, Gender gender, DateTime? birthDay, string rg)
        {
            _name = name;
            _gender = gender;
            _genderId = gender != null ? gender.Id : 0;
            _birthDay = birthDay;
            _rg = rg;
        }


        public override IResponse Validate()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsLowerOrEqualsThan(_name, 60, nameof(_name), "The inserted document must contain a maximum of 60 characters")
                .IsNotNullOrEmpty(_name, nameof(_name), "This property is mandatory")
                .IsRG(_rg, nameof(_rg), "The inserted document must contain a maximum of 12 characters")
                );

            if (_birthDay != null)
            {
                var date = _birthDay ?? DateTime.Now;
                AddNotifications(new Contract<string>()
                .Requires()
                .IsLowerThan(date, DateTime.Now, nameof(_birthDay), "The date entered cannot be greater than today")
                );
            }

            if (IsValid)
                return new ResponseOk<PersonFis>(this, 1);

            return new ResponseError<PersonFis>("400", "The registered individual is filled in incorrectly.", this.Notifications, this.Notifications.Count);
        }
    }
}
