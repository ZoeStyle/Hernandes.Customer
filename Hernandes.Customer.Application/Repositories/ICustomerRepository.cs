using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<IResponse> Add(Domain.Entities.Customer customer);
        Task<IResponse> Update(Domain.Entities.Customer customer);
        Task<IResponse> GetAsyncFis(string cpf, string name, string rg);
        Task<IResponse> GetAsyncJur(string cnpj, string corporateName, string fantasyName);
        Task<IResponse> GetByIdAsync(int id);
        Task<IResponse> GetAll();
    }
}
