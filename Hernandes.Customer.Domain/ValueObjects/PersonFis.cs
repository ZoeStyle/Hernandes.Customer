using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.Work;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class PersonFis
        : ValueObject
    {
        private string _name;
        private Gender _gender;
        private DateTime? _birthDay;
        private string _rg;

        public string Name { get => _name; }
        public Gender Gender { get => _gender; }
        public DateTime? BirthDay { get => _birthDay; }
        public string Rg { get => _rg; }

        public PersonFis(string name, Gender gender, DateTime? birthDay, string rg)
        {
            _name = name;
            _gender = gender;
            _birthDay = birthDay;
            _rg = rg;
        }

        public override string ToString()
        {
            return "{ Name : \"" + Name + "\", Gender : \"" + Gender.ToString() + "\", BirthDay : \"" + BirthDay + "\", Rg : \"" + Rg + "\" }";
        }
    }
}
