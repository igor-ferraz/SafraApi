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
    [ServiceFilter(typeof(AuthFilter))]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sale sale)
        {
            var saleId = await saleService.Create(sale);

            var paymentUrl = $"https://safraapi.azurewebsites.net/api/v1/payment/{saleId}";
            //var paymentUrl = $"http://localhost:54671/api/v1/payment/{saleId}";

            if (saleId != null)
                return Created("Sale", new
                {
                    Url = paymentUrl
                });
            else
                return BadRequest();
        }
    }
}