using Library.Web.Models;
using Library.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            ResponseDto? response = await _userService.GetUsersAsync();

            if(response.IsSuccess && response.Result != null)
            {
                IEnumerable<UserDto> users = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(Convert.ToString(response.Result));

                return View(users);
            }
            else
            {
                TempData["error"] = response.Message;
                return View();
            }
        }
    }
}
