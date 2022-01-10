using MongoDB.Driver;

namespace Hernandes.Customer.Infra.Context
{
    public interface IStoreDataContext
    {
        public IMongoCollection<Domain.Entities.Customer> Customers { get; }

    }
}
