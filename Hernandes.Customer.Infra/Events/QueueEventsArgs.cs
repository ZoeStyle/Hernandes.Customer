namespace Hernandes.Customer.Infra.Events
{
    public class QueueEventsArgs : EventArgs
    {
        public QueueEventsArgs(Domain.Entities.Customer customer)
        {
            Customers = customer;
        }

        public Domain.Entities.Customer Customers { get; }
    }
}
