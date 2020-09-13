using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Safra.Domain.ApplicationServices;
using Safra.Domain.Models;

namespace Safra.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            var credentials = await userService.Login(login);

            if (credentials == null)
                return Unauthorized();

            return Ok(credentials);
        }
    }
}