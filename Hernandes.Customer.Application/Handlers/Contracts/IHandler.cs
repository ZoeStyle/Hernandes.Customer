using Hernandes.Customer.Application.Commands.Contracts;
using Hernandes.Customer.Response.Contracts;

namespace Hernandes.Customer.Application.Handlers.Contracts
{
    public interface IHandler<T>
        where T : ICommand
    {
        Task<IResponse> Handle(T request);
    }
}
