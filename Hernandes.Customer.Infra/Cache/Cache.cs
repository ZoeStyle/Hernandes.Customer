namespace Hernandes.Customer.Infra.Cache
{
    public static class Cache
    {
        public static IDictionary<string, Domain.Entities.Customer> _dictionary;

        public static IDictionary<string, Domain.Entities.Customer> Dictionary => _dictionary;

        public static void AddDictionary(this IDictionary<string, Domain.Entities.Customer> value)
        {
            try
            {
                _dictionary.Clear();
                foreach(var item in value)
                    _dictionary[item.Key] = item.Value;
            }
            catch
            {
                _dictionary = value;
            }
        }
    }
}
