using Hernandes.Customer.Application.Repositories;
using Hernandes.Customer.Response;
using Hernandes.Customer.Response.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hernandes.Customer.Infrastructure.Test.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Domain.Entities.Customer> _context;

        public CustomerRepository() =>
            _context = new List<Domain.Entities.Customer>();

        public async Task<IResponse> Add(Domain.Entities.Customer customer)
        {
            var id = _context.Count + 1;
            customer.SetId(id);
            _context.Add(customer);
            return new ResponseOk<Domain.Entities.Customer>(customer);
        }

        public async Task<IResponse> GetAll()
        {
            var customerList = _context.AsQueryable().ToList();

            return new ResponseOk<IReadOnlyCollection<Domain.Entities.Customer>>(customerList);
        }

        public async Task<IResponse> GetAsyncFis(string cpf, string name, string rg)
        {
            Domain.Entities.Customer customer = null;

            if (!string.IsNullOrEmpty(cpf))
                customer = _context.AsQueryable().FirstOrDefault(find => find.Document.DocumentNumber == cpf);
            else if (!string.IsNullOrEmpty(name))
                customer = _context.AsQueryable().FirstOrDefault(find => find.PersonFis.Name == name);
            else if (!string.IsNullOrEmpty(rg))
                customer = _context.AsQueryable().FirstOrDefault(find => find.PersonFis.Rg == rg);

            if (customer != null)
                return new ResponseOk<Domain.Entities.Customer>(customer);

            return new ResponseError<Domain.Entities.Customer>("404", "NotFound", null, 1);
        }

        public async Task<IResponse> GetAsyncJur(string cnpj, string corporateName, string fantasyName)
        {
            Domain.Entities.Customer customer = null;

            if (!string.IsNullOrEmpty(cnpj))
                customer = _context.AsQueryable().FirstOrDefault(find => find.Document.DocumentNumber == cnpj);
            else if (!string.IsNullOrEmpty(corporateName))
                customer = _context.AsQueryable().FirstOrDefault(find => find.PersonJur.CorporateName == corporateName);
            else if (!string.IsNullOrEmpty(fantasyName))
                customer = _context.AsQueryable().FirstOrDefault(find => find.PersonJur.FantasyName == fantasyName);

            if (customer != null)
                return new ResponseOk<Domain.Entities.Customer>(customer);

            return new ResponseError<Domain.Entities.Customer>("404", "NotFound", null, 1);
        }

        public async Task<IResponse> GetByIdAsync(int id)
        {
            var customer = _context.AsQueryable().FirstOrDefault(newCustomer => newCustomer.Id == id);

            if (customer != null)
                return new ResponseOk<Domain.Entities.Customer>(customer);

            return new ResponseError<Domain.Entities.Customer>("404", "NotFound", null, 1);
        }

        public async Task<IResponse> Update(Domain.Entities.Customer customer)
        {
            var find = await GetByIdAsync(customer.Id);

            if (find.HasError())
                return find;

            var updateCustomer = (Domain.Entities.Customer)find.ResponseObj();

            _context.Remove(updateCustomer);
            _context.Add(customer);

            throw new System.NotImplementedException();
        }
    }
}
