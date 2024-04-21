using Library.Web.Models;
using Library.Web.Service.IService;
using Library.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Library.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Login actions
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                // sign in user
                await SignInUser(loginResponseDto);

                // set token
                _tokenProvider.SetToken(loginResponseDto.Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(obj);
            }
        }
        #endregion

        #region Register actions
        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>() 
            {
                new SelectListItem {Text = SD.RoleAdmin, Value = SD.RoleAdmin},
                new SelectListItem {Text = SD.RoleCustomer, Value = SD.RoleCustomer}
            };

            ViewBag.RoleList = roleList;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            ResponseDto result = await _authService.RegisterAsync(obj);
            ResponseDto assignRole;

            if (result != null && result.IsSuccess)
            {
                if(string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;
                }

                assignRole = await _authService.AssignRoleAsync(obj);

                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration successfully!";
                    return RedirectToAction(nameof(Login));
                }
            }

            var roleList = new List<SelectListItem>() 
            {
                new SelectListItem {Text = SD.RoleAdmin, Value = SD.RoleAdmin},
                new SelectListItem {Text = SD.RoleCustomer, Value = SD.RoleCustomer}
            };

            ViewBag.RoleList = roleList;

            TempData["error"] = result.Message;
            return View(obj);
        }
        #endregion

        [HttpGet]
        public IActionResult AssignRole()
        {
            return View();
        }

        // Logout action
        public async Task<IActionResult> LogOut()
        {
            // clear token : this is IMPORTANT
            _tokenProvider.ClearToken();

            // sign out user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // redirect to index page in Home
            return RedirectToAction("Index", "Home");
        }
        
        // user sign in to the system
        private async Task SignInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();

            // read token from backend
            var jwt = handler.ReadJwtToken(model.Token);

            // creating identity for old user
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            // adding claims
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            // creating principal using identity
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
