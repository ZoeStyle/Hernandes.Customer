using Hernandes.Customer.Application.Repositories;
using Hernandes.Customer.Infra.Context;
using Hernandes.Customer.Notifications.Notifications;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Hernandes.Customer.Infra.Repositories
{
    public class CustomerRepository : Notifiable<Notification>, ICustomerRepository
    {
        private readonly IStoreDataContext _context;

        public CustomerRepository(IStoreDataContext context)
        {
            _context = context;
        }

        public async Task<IResponse> Add(Domain.Entities.Customer customer)
        {
            try
            {
                await _context.Customers.InsertOneAsync(customer);
                return new ResponseOk<Domain.Entities.Customer>(customer);
            }
            catch (Exception e)
            {
                AddNotification("Error", e.Message);
                return new ResponseError<Domain.Entities.Customer>("400", e.Message, Notifications, Notifications.Count);
            }
        }

        public async Task<IResponse> GetAll()
        {
            try
            {
                var result = await _context.Customers.Find(x => x.Id != null).ToListAsync();

                if (result != null)
                    return new ResponseOk<IEnumerable<Domain.Entities.Customer>>(result);

                AddNotification("Error", "NotFound");

                return new ResponseError<IEnumerable<Domain.Entities.Customer>>("404", "NotFound", Notifications, Notifications.Count);

            }
            catch (Exception ex)
            {
                AddNotification("Error", ex.Message);

                return new ResponseError<IEnumerable<Domain.Entities.Customer>>("400", ex.Message, Notifications, Notifications.Count);
            }
        }

        public async Task<IResponse> GetAsyncFis(string cpf, string name, string rg)
        {
            Domain.Entities.Customer findList = null;
            try
            {
                if (!string.IsNullOrEmpty(cpf))
                    findList = await _context.Customers.Find(x => x.Document.DocumentNumber == cpf).FirstOrDefaultAsync();
                else if (!string.IsNullOrEmpty(name))
                    findList = await _context.Customers.Find(x => x.PersonFis.Name == name).FirstOrDefaultAsync();
                else if (!string.IsNullOrEmpty(rg))
                    findList = await _context.Customers.Find(x => x.PersonFis.Rg == rg).FirstOrDefaultAsync();

                if (findList != null)
                    return new ResponseOk<Domain.Entities.Customer>(findList);

                AddNotification("Error", "NotFound");

                return new ResponseError<Domain.Entities.Customer>("404", "NotFound", Notifications, Notifications.Count);

            }
            catch (Exception ex)
            {
                AddNotification("Error", ex.Message);

                return new ResponseError<Domain.Entities.Customer>("400", ex.Message, Notifications, Notifications.Count);
            }
        }

        public async Task<IResponse> GetAsyncJur(string cnpj, string corporateName, string fantasyName)
        {
            Domain.Entities.Customer findList = null;
            try
            {
                if (!string.IsNullOrEmpty(cnpj))
                    findList = await _context.Customers.Find(x => x.Document.DocumentNumber == cnpj).FirstOrDefaultAsync();
                else if (!string.IsNullOrEmpty(corporateName))
                    findList = await _context.Customers.Find(x => x.PersonJur.CorporateName == corporateName).FirstOrDefaultAsync();
                else if (!string.IsNullOrEmpty(fantasyName))
                    findList = await _context.Customers.Find(x => x.PersonJur.FantasyName == fantasyName).FirstOrDefaultAsync();

                if (findList != null)
                    return new ResponseOk<Domain.Entities.Customer>(findList);

                AddNotification("Error", "NotFound");

                return new ResponseError<Domain.Entities.Customer>("404", "NotFound", Notifications, Notifications.Count);

            }
            catch (Exception ex)
            {
                AddNotification("Error", ex.Message);

                return new ResponseError<Domain.Entities.Customer>("400", ex.Message, Notifications, Notifications.Count);
            }
        }

        public async Task<IResponse> GetByIdAsync(string id)
        {
            try
            {

                var find = await _context.Customers.Find(x => x.Id == id).FirstOrDefaultAsync();

                if (find != null)
                    return new ResponseOk<Domain.Entities.Customer>(find);

                AddNotification("Error", "NotFound");

                return new ResponseError<Domain.Entities.Customer>("404", "NotFound", Notifications, Notifications.Count);

            }
            catch (Exception ex)
            {
                AddNotification("Error", ex.Message);

                return new ResponseError<IEnumerable<Domain.Entities.Customer>>("400", ex.Message, Notifications, Notifications.Count);
            }
        }

        public async Task<IResponse> Update(Domain.Entities.Customer customer)
        {
            try
            {
                _context.Customers.ReplaceOne(x => x.Id == customer.Id, customer);

                return new ResponseOk<Domain.Entities.Customer>(customer);
            }
            catch (Exception e)
            {
                AddNotification("Error", e.Message);
                return new ResponseError<Domain.Entities.Customer>("400", e.Message, Notifications, Notifications.Count);
            }
        }
    }
}
