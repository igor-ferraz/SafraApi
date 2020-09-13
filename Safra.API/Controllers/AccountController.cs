using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using Safra.API.Filters;
using Safra.Domain.ApplicationServices;
using Safra.Domain.Models;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasicData(string id)
        {
            var basicAccount = await service.GetBasicData(id);

            if (basicAccount == null)
                return BadRequest();

            return Ok(basicAccount);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProducts(string id, bool showInactives = false)
        {
            var products = await service.GetProducts(id, showInactives);
            return Ok(products);
        }

        [HttpGet("{id}/balances")]
        public async Task<IActionResult> GetBalances(string id)
        {
            var balances = await service.GetBalances(id);
            return Ok(balances);
        }

        [HttpGet("{id}/transactions")]
        public async Task<IActionResult> GetTransactions(string id)
        {
            var transactions = await service.GetTransactions(id);
            return Ok(transactions);
        }

        [HttpPost("optin")]
        public async Task<IActionResult> OptIn([FromBody] OptIn optIn, [FromHeader] string authorization)
        {
            var result = await service.OptIn(optIn, authorization);

            if (result)
                return Created("OptIn", null);

            return BadRequest();
        }
    }
}
