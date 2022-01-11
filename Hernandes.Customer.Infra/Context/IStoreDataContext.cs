using Hernandes.Customer.Infra.Events;
using MongoDB.Driver;

namespace Hernandes.Customer.Infra.Context
{
    public interface IStoreDataContext
    {
        public IMongoCollection<Domain.Entities.Customer> Customers { get; }

        void Add(Queue<Domain.Entities.Customer> queue);

        void Update(Queue<Domain.Entities.Customer> queue);

    }
}
