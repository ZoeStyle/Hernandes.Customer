using Hernandes.Customer.Application.Repositories;
using Hernandes.Customer.Notifications.Notifications;

namespace Hernandes.Customer.Application.Handlers
{
    public partial class CustomerHandler
        : Notifiable<Notification>
    {
        private readonly ICustomerRepository _repository;

        public CustomerHandler(ICustomerRepository repository) =>
            _repository = repository;

    }
}
