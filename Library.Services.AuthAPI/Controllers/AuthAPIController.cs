using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {

        // Register
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();  
        }
    }
}
