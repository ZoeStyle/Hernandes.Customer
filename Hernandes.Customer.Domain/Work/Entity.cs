using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Domain.Work
{
    public abstract class Entity 
    {
        public Entity()
        {
            _Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
        }

        string _Id;

        public virtual string Id
        {
            get => _Id;
            protected set => _Id = value;
        }

        public abstract IResponse Validate();
    }
}