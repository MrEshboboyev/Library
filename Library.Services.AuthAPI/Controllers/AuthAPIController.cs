using Library.Services.AuthAPI.Models.Dto;
using Library.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private IAuthService _authService;
        protected ResponseDto _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

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
