using Hernandes.Customer.Domain.ValueObjects;
using Hernandes.Customer.Domain.Work;

namespace Hernandes.Customer.Domain.Enums
{
    public class DocumentType :
            Enumeration
    {
        public static DocumentType Juridica = new(1, nameof(Juridica));
        public static DocumentType Fisica = new(2, nameof(Fisica));

        public DocumentType(int id, string name)
            : base(id, name) { }

        public Document Document { get; }
    }
}
