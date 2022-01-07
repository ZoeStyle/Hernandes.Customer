using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Application.Commands.Contracts
{
    public interface ICommand
    {
        IResponse Validate();
    }
}
