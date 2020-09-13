using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Safra.Application.Services;

namespace Safra.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Auth([FromHeader] string authorization)
        {
            if (authorization != null)
            {
                var token = await service.Authorize(authorization.Split(' ')[1]);

                if (token != null)
                    return Ok(token);
            }

            return Unauthorized();
        }
    }
}