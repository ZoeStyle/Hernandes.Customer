using Hernandes.Customer.Application.Repositories;
using Hernandes.Customer.Infra.Context;
using Hernandes.Customer.Infra.Events;
using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;
using MongoDB.Driver;
using Hernandes.Customer.Infra.Cache;
using System.Collections.Generic;
using System.Linq;

namespace Hernandes.Customer.Infra.Repositories
{
    public class CustomerRepository : Notifiable<Notification>, ICustomerRepository
    {
        #region Delegates
        delegate void InsertEventHandler(object sender, QueueEventsArgs e);
        delegate void UpdateEventHandler(object sender, QueueEventsArgs e);
        delegate void ConvertToListEventHandler(object sender, ListEventsArgs e);
        #endregion

        #region Events
        event InsertEventHandler InsertDb;
        event UpdateEventHandler UpdateDb;
        event ConvertToListEventHandler Convert;
        #endregion

        #region variables
        readonly IStoreDataContext _context;
        IDictionary<string, Domain.Entities.Customer> _dictionary;
        Queue<Domain.Entities.Customer> _queue/* = new Queue<Domain.Entities.Customer>()*/;
        IList<Domain.Entities.Customer> _list /*= new List<Domain.Entities.Customer>()*/;
        #endregion

        public CustomerRepository(IStoreDataContext context)
        {
            _context = context;
            _dictionary = new Dictionary<string, Domain.Entities.Customer>();
            _queue = new Queue<Domain.Entities.Customer>();
            _list = new List<Domain.Entities.Customer>();

            LoadList();
        }

        public async Task<IResponse> Add(Domain.Entities.Customer customer)
        {
            InsertDb += new InsertEventHandler(InsertDatabase);

            HandlerCustomer(customer);

            return new ResponseOk<Domain.Entities.Customer>(customer);
        }

        public async Task<IResponse> GetAll()
        {
            var result = _list.AsQueryable().ToList();

            if (result.Count > 0)
                return new ResponseOk<List<Domain.Entities.Customer>>(result);

            AddNotification("Error", "NotFound");

            return new ResponseError<IEnumerable<Domain.Entities.Customer>>("404", "NotFound", Notifications, Notifications.Count);
        }

        public async Task<IResponse> GetAsyncFis(string cpf, string name, string rg)
        {
            Domain.Entities.Customer findList = null;

            if (!string.IsNullOrEmpty(cpf))
                findList = _list.AsQueryable().FirstOrDefault(x => x.Document.DocumentNumber == cpf);
            else if (!string.IsNullOrEmpty(name))
                findList = _list.AsQueryable().FirstOrDefault(x => x.PersonFis.Name == name);
            else if (!string.IsNullOrEmpty(rg))
                findList = _list.AsQueryable().FirstOrDefault(x => x.PersonFis.Rg == rg);

            if (findList != null)
                return new ResponseOk<Domain.Entities.Customer>(findList);

            AddNotification("Error", "NotFound");

            return new ResponseError<Domain.Entities.Customer>("404", "NotFound", Notifications, Notifications.Count);
        }

        public async Task<IResponse> GetAsyncJur(string cnpj, string corporateName, string fantasyName)
        {
            Domain.Entities.Customer findList = null;

            if (!string.IsNullOrEmpty(cnpj))
                findList = _list.AsQueryable().FirstOrDefault(x => x.Document.DocumentNumber == cnpj);
            else if (!string.IsNullOrEmpty(corporateName))
                findList = _list.AsQueryable().FirstOrDefault(x => x.PersonJur.CorporateName == corporateName);
            else if (!string.IsNullOrEmpty(fantasyName))
                findList = _list.AsQueryable().FirstOrDefault(x => x.PersonJur.FantasyName == fantasyName);

            if (findList != null)
                return new ResponseOk<Domain.Entities.Customer>(findList);

            AddNotification("Error", "NotFound");

            return new ResponseError<Domain.Entities.Customer>("404", "NotFound", Notifications, Notifications.Count);
        }

        public async Task<IResponse> GetByIdAsync(string id)
        {
            var find = _list.AsQueryable().FirstOrDefault(x => x.Id == id);

            if (find != null)
                return new ResponseOk<Domain.Entities.Customer>(find);

            AddNotification("Error", "NotFound");

            return new ResponseError<Domain.Entities.Customer>("404", "NotFound", Notifications, Notifications.Count);
        }

        public async Task<IResponse> Update(Domain.Entities.Customer customer)
        {
            UpdateDb += new UpdateEventHandler(UpdateDatabase);

            HandlerCustomer(customer);

            return new ResponseOk<Domain.Entities.Customer>(customer);
        }

        void HandlerCustomer(Domain.Entities.Customer customer)
        {
            Convert += new ConvertToListEventHandler(ConvertToList);

            if (!_dictionary.ContainsKey(customer.Id))
                OnInsertDatabase(new QueueEventsArgs(customer));
            else
            OnUpdateDatabase(new QueueEventsArgs(customer));
        }

        public virtual void OnInsertDatabase(QueueEventsArgs e)
        {
            if (InsertDb != null)
            {
                var customer = e.Customers;
                var key = e.Customers.Id;
                _dictionary[key] = customer;
                _dictionary.AddDictionary();
                InsertDb(this, e);
                if (Convert != null)
                    Convert(this, new ListEventsArgs(_dictionary));
            }
        }

        public virtual void OnUpdateDatabase(QueueEventsArgs e)
        {
            if (UpdateDb != null)
            {
                var customer = e.Customers;
                var key = e.Customers.Id;
                _dictionary.Remove(key);
                _dictionary[key] = customer;
                UpdateDb(this, e);
                if (Convert != null)
                    Convert(this, new ListEventsArgs(_dictionary));
            }
        }

        public virtual void OnConvertToList(ListEventsArgs e)
        {
            if (Convert != null)
                Convert(this, e);
        }
        
        void InsertDatabase(object sesnder, QueueEventsArgs e)
        {
            var customer = e.Customers;
            EnqueueInsert(customer);
        }

        void UpdateDatabase(object sender, QueueEventsArgs e)
        {
            var customer = e.Customers;
            EnqueueUpdate(customer);
        }

        void ConvertToList(object sender, ListEventsArgs e)
        {
            var dictionary = e.Dictionary;
            _list.Clear();

            foreach (var item in dictionary)
                _list.Add(item.Value);
        }

        void EnqueueInsert(Domain.Entities.Customer customer)
        {
            _queue.Enqueue(customer);
            _context.Add(_queue);
        }

        void EnqueueUpdate(Domain.Entities.Customer customer)
        {
            _queue.Enqueue(customer);
            _context.Update(_queue);
        }

        async void LoadList()
        {
            Convert += new ConvertToListEventHandler(ConvertToList);

            var find = await _context.Customers.Find(x => x.Id != null).ToListAsync();

            foreach (var item in find)
                _dictionary[item.Id] = item;

            OnConvertToList(new ListEventsArgs(_dictionary));
        }
    }
}
