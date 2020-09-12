using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using Safra.API.Filters;
using Safra.Domain.ApplicationServices;

namespace Safra.API.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProducts(int id, bool showInactives = false)
        {
            var products = await service.GetProducts(id, showInactives);
            return Ok(products);
        }
    }
}
