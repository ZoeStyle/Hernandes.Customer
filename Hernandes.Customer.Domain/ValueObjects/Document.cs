using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.Work;

namespace Hernandes.Customer.Domain.ValueObjects
{
    public class Document:
        ValueObject
    {
        private string _documentNumber;
        private DocumentType _type;
        private int _typeId;

        //public Customer Customer { get; }
        public string DocumentNumber { get => _documentNumber; }
        public DocumentType Type { get => _type; }
        private Document() { }

        public Document(string documentNumber, DocumentType type)
        {
            _documentNumber = documentNumber;
            _type = type;
        }

        public override string ToString()
        {
            return "{ DocumentNumber : \"" + DocumentNumber + "\", Type : " + Type.ToString() + "}";
        }
    }
}
