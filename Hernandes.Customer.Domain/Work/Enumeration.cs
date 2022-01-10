namespace Hernandes.Customer.Domain.Work
{
    public abstract class Enumeration : IComparable
    {
        private string _name;
        private int _id;
        public string Name { get => _name; }

        public int Id { get => _id; }

        private Enumeration() { }
        
        protected Enumeration(int id, string name) => (_id, _name) = (id, name);

        public override string ToString() => "{ Name : \"" + Name + "\" }";

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }
}
