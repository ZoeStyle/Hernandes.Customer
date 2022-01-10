using Hernandes.Customer.Domain.ValueObjects;
using Hernandes.Customer.Domain.Work;

namespace Hernandes.Customer.Domain.Enums
{
    public class Gender :
            Enumeration
    {
        public static Gender Feminino = new(1, nameof(Feminino));
        public static Gender Masculino = new(2, nameof(Masculino));
        public static Gender Outros = new(3, nameof(Outros));
        public Gender(int id, string name)
            : base(id, name) { }
    }
}
