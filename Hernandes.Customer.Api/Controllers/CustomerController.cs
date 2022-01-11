using Hernandes.Customer.Application.Commands;
using Hernandes.Customer.Application.Handlers;
using Hernandes.Customer.Application.Repositories;
using Hernandes.Customer.Response.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hernandes.Customer.Api.Controllers
{
    [Route("v1/[controller]"), Produces("application/json"), Consumes("application/json")]
    public class CustomerController : Controller
    {
        /// <summary>
        /// Gets all registered customers in the database / Obtem todos os clientes cadastrados na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")/*, Authorize*/]
        public async Task<ActionResult> GetAll([FromServices] ICustomerRepository repository)
        {
            var find = await repository.GetAll();

            return Ok(find.ResponseObj());
        }

        /// <summary>
        /// Gets a customer through one of the completed queries / Obtém um cliente através de umas das query preenchida
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cpf">188.963.553-70</param>
        /// <param name="name">Sophie Mariane Mariah Pinto</param>
        /// <param name="rg">31.558.190-6</param>
        /// <returns></returns>
        [HttpGet, Route("PersonFis")/*, Authorize*/]
        public async Task<ActionResult> GetAsyncFis([FromServices] ICustomerRepository repository, [FromQuery] string cpf, [FromQuery] string name, [FromQuery] string rg)
        {
            if (string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(rg))
                return BadRequest(new { Message = "It is necessary to inform one of the queries" });

            var find = await repository.GetAsyncFis(cpf, name, rg);

            if (find.HasError())
                return BadRequest(find.Error());

            return Ok(find);
        }

        /// <summary>
        /// Gets a customer through one of the completed queries / Obtém um cliente através de umas das query preenchida
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cnpj">19.204.523/0001-88</param>
        /// <param name="companyName">Andreia e Sarah Buffet ME</param>
        /// <param name="fantasyName">Andreia e Sarah Buffet ME</param>
        /// <returns></returns>
        [HttpGet, Route("PersonJur")/*, Authorize*/]
        public async Task<ActionResult> GetAsyncJur([FromServices] ICustomerRepository repository, [FromQuery] string cnpj, [FromQuery] string companyName, [FromQuery] string fantasyName)
        {
            if (string.IsNullOrEmpty(cnpj) && string.IsNullOrEmpty(companyName) && string.IsNullOrEmpty(fantasyName))
                return BadRequest(new { Message = "It is necessary to inform one of the queries" });

            var find = await repository.GetAsyncJur(cnpj, companyName, fantasyName);

            if (find.HasError())
                return BadRequest(find.Error());

            return Ok(find.ResponseObj());
        }
        
        /// <summary>
        /// Create a new customer as a individual / Crie um novo cliente como uma pessoa Fisica
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("PersonFis")/*, Authorize*/]
        public async Task<ActionResult<IResponse>> CreatePesonFis([FromServices] CustomerHandler handler, [FromBody] CreateCustomerPersonFisCommand command)
        {
            if (command == null)
                return BadRequest(new { Error = "Invalid request"});

            var result = await handler.Handle(command);

            if (result.HasError())
                return BadRequest(result.Error());

            return Ok(result.ResponseObj());
        }

        /// <summary>
        /// Create a new customer as a Company / Crie um novo cliente como uma pessoa Juridica 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("PersonJur")/*, Authorize*/]
        public async Task<ActionResult<IResponse>> CreatePersonJur([FromServices] CustomerHandler handler, [FromBody] CreateCustomerPersonJurCommand command)
        {
            if (command == null)
                return BadRequest(new { Error = "Invalid request" });

            var result = await handler.Handle(command);

            if (result.HasError())
                return BadRequest(result.Error());

            return Ok(result.ResponseObj());
        }

        /// <summary>
        /// Update the individual customer / Atualiza o cliente pessoa Fisica
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut, Route("PersonFis/{id}")/*, Authorize*/]
        public async Task<ActionResult<IResponse>> PutPesonFis([FromServices] CustomerHandler handler, [FromBody] UpdateCustomerPersonFisCommand command, [FromRoute] string id)
        {
            if (command == null)
                return BadRequest(new { Error = "Invalid request" });

            if (id != command.Id)
                return BadRequest(new { message = "invalid id" });

            var result = await handler.Handle(command);

            if (result.HasError())
                return BadRequest(result.Error());

            return Ok(result.ResponseObj());
        }

        /// <summary>
        /// Update the corporate customer / Atualiza o cliente pessoa Juridica 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut, Route("PersonJur/{id}")/*, Authorize*/]
        public async Task<ActionResult<IResponse>> PutPersonJur([FromServices] CustomerHandler handler, [FromBody] UpdateCustomerPersonJurCommand command, [FromRoute] string id)
        {
            if (command == null)
                return BadRequest(new { Error = "Invalid request" });

            if (id != command.Id)
                return BadRequest(new { message = "invalid id" });
            
            var result = await handler.Handle(command);

            if (result.HasError())
                return BadRequest(result.Error());

            return Ok(result.ResponseObj());
        }

    }
}