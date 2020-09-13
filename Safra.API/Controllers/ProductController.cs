using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Safra.API.Filters;
using Safra.Domain.ApplicationServices;
using Safra.Domain.InfrastructureServices;
using Safra.Domain.Models;

namespace Safra.API.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly IFileService fileService;

        private const string ImagesPath = "ProductsImages";

        public ProductController(IProductService service, IFileService fileService)
        {
            this.service = service;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool showInactives = false)
        {
            var products = await service.Get(showInactives);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await service.Get(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Product product)
        {
            var result = await service.Add(product);
            return Ok(result);
        }

        [HttpPost("{id:int}/image")]
        public async Task<IActionResult> UploadImage(int id, [FromForm(Name = "image")] IFormFile image)
        {
            if (image != null && fileService.IsImage(image))
            {
                var files = Directory.GetFiles(ImagesPath, $"Product_{id}.*");

                foreach (var file in files)
                {
                    System.IO.File.Delete(file);
                }

                var result = await fileService.Save(image, $"Product_{id}", ImagesPath);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("{id:int}/image")]
        public async Task<IActionResult> DownloadImage(int id)
        {
            var filePath = Directory.GetFiles(ImagesPath, $"Product_{id}.*").FirstOrDefault();

            if (!String.IsNullOrEmpty(filePath))
            {
                var fileName = Path.GetFileName(filePath);
                var webClient = new System.Net.WebClient();
                var data = webClient.DownloadData(filePath);
                var content = new MemoryStream(data);
                var contentType = "application/octet-stream";

                return File(content, contentType, fileName);
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Product product)
        {
            var result = await service.Update(product);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await service.Delete(id);
            return Ok(result);
        }
    }
}
