using Library.Services.AuthAPI.Models.Dto;
using Library.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.AuthAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected ResponseDto? _response;
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            _response = new();
        }

        [HttpGet]
        public async Task<ResponseDto?> Get()
        {
            try
            {
                _response.Result = await _userService.GetAllUsers();
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ResponseDto?> GetUserByEmail(string email)
        {
            try
            {
                _response.Result = await _userService.GetUserByEmail(email);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }
    }
}
