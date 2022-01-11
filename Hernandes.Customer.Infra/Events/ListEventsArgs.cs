namespace Hernandes.Customer.Infra.Events
{
    public class ListEventsArgs : EventArgs
    {
        public ListEventsArgs(IDictionary<string, Domain.Entities.Customer> dictionary)
        {
            Dictionary = dictionary;
        }

        public IDictionary<string, Domain.Entities.Customer> Dictionary { get; }
    }
}
