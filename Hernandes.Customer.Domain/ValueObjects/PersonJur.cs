using Hernandes.Customer.Domain.Work;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class PersonJur
        : ValueObject
    {
        private string _corporateName;
        private string _fantasyName;

        public string CorporateName { get => _corporateName; }
        public string FantasyName { get => _fantasyName; }
        private PersonJur()
        { }

        public PersonJur(string corporateName, string fantasyName)
        {
            _corporateName = corporateName;
            _fantasyName = fantasyName;
        }

        public override string ToString()
        {
            return "{ CorporateName : \"" + CorporateName + "\", FantasyName : \"" + FantasyName + "\"}";
        }
    }
}
