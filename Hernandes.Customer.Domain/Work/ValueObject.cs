using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.Work
{
    public abstract class ValueObject : Notifiable<Notification>
    {
        int _Id;

        public virtual int Id
        {
            get => _Id;
            protected set => _Id = value;
        }

        public abstract IResponse Validate();

    }
}
