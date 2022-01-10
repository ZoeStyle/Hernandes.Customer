using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Hernandes.Customer.Infra.Context
{
    public class StoreDataContext : IStoreDataContext
    {
        public StoreDataContext(IConfiguration configuration)
        {

            var settings = MongoClientSettings.FromConnectionString(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
           
            var client = new MongoClient(settings);

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Customers = database.GetCollection<Domain.Entities.Customer>(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        }
        public IMongoCollection<Domain.Entities.Customer> Customers { get; }
    }
}
