using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Safra.API.Filters;
using Safra.Domain.ApplicationServices;
using Safra.Domain.Models;

namespace Safra.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [ServiceFilter(typeof(AuthFilter))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sale sale)
        {
            var saleId = await saleService.Create(sale);

            var paymentUrl = $"https://safraapi.azurewebsites.net/payment/{saleId}";
            //var paymentUrl = $"http://localhost:54671/api/v1/payment/{saleId}";

            if (saleId != null)
                return Created(
                    "Sale",
                    new
                    {
                        Url = paymentUrl
                    });
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var sales = await saleService.Get(id);

            if (sales != null)
                return Ok(sales);

            return NotFound();
        }

        [HttpGet("{id}/paymentMethod/{paymentMethod:int}")]
        public async Task<IActionResult> Pay(string saleId, int paymentMethod)
        {
            if (paymentMethod == 3 || paymentMethod == 5)
                return Ok();

            return BadRequest();
        }
    }
}