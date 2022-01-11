using Hernandes.Customer.Infra.Events;
using Hernandes.Customer.Notifications.Notifications;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Hernandes.Customer.Infra.Context
{
    public class StoreDataContext : Notifiable<Notification>, IStoreDataContext
    {
        public StoreDataContext(IConfiguration configuration)
        {

            var settings = MongoClientSettings.FromConnectionString(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
           
            var client = new MongoClient(settings);

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Customers = database.GetCollection<Domain.Entities.Customer>(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        }
        
        public IMongoCollection<Domain.Entities.Customer> Customers { get; }

        public async void Add(Queue<Domain.Entities.Customer> queue)
        {
            foreach(var item in queue)
                await Customers.InsertOneAsync(item);
        }

        public async void Update(Queue<Domain.Entities.Customer> queue)
        {
            foreach (var item in queue)
                try
                {
                    await Customers.ReplaceOneAsync(x => x.Id == item.Id, item);
                }
                catch
                {
                    // abort
                }
        }
    }
}
