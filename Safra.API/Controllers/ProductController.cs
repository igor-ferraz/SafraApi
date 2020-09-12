using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Safra.API.Filters;
using Safra.Domain.ApplicationServices;

namespace Safra.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [ServiceFilter(typeof(AuthFilter))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _service.Get();
            return Ok(products);
        }
    }
}
