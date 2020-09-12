using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Safra.API.Filters;
using Safra.Domain.ApplicationServices;
using Safra.Domain.Models;

namespace Safra.API.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool showInactives = false)
        {
            var products = await _service.Get(showInactives);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _service.Get(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Product product)
        {
            var result = await _service.Add(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Product product)
        {
            var result = await _service.Update(product);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _service.Delete(id);
            return Ok(result);
        }
    }
}
