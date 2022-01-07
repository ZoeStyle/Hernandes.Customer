using Hernandes.Customer.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hernandes.Customer.Api.Controllers
{
    [Route("v1/[controller]")]
    public class AccessTokenController : Controller
    {
        /// <summary>
        /// Fetch the token for API access / Busca o token para acesso a API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate() => new
            {
                Token = TokenService.GenerateToken()
            };
    }
}
