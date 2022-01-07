using Hernandes.Customer.Domain.Enums;
using Hernandes.Customer.Domain.Work;
using Hernandes.Customer.Notifications.Validations;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;

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
        public int TypeId { get => _typeId; }
        private Document() { }

        public Document(string documentNumber, DocumentType type)
        {
            _documentNumber = documentNumber;
            _type = type;
            _typeId = type.Id;
        }

        public override IResponse Validate()
        {
            ValidatingNull();
            ValidatingDocument();

            if (IsValid)
                return new ResponseOk<Document>(this, 1);

            return new ResponseError<Document>("400", "The document entered is incorrect.", this.Notifications, this.Notifications.Count);

        }

        private void ValidatingNull()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsNotNullOrEmpty(_documentNumber, nameof(_documentNumber), "The document number cannot be null.")
                .IsNotNull(_type, nameof(_type), "The type of document entered cannot be null.")
                );
        }

        protected void ValidatingDocument()
        {
            switch (Type.Id)
            {
                case 1:
                    AddNotifications(new Contract<string>()
                        .Requires()
                        .IsCNPJ(_documentNumber, nameof(_documentNumber), "The document entered is incorrect.")
                        );
                    break;
                case 2:
                    AddNotifications(new Contract<string>()
                        .Requires()
                        .IsCPF(_documentNumber, nameof(_documentNumber), "The document entered is incorrect.")
                        );
                    break;
            }
        }

    }
}
