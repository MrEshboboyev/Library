using Library.Web.Models;
using Library.Web.Service.IService;
using Library.Web.Utility;
using static Library.Web.Utility.SD;

namespace Library.Web.Service
{
    public class UserService : IUserService
    {
        // DI for BaseService
        private readonly IBaseService _baseService;

        public UserService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetUsersAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.AuthAPIBase + "/api/users"
            });
        }
        public async Task<ResponseDto?> GetUserByEmailAsync(string email)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.AuthAPIBase + "/api/users/GetUserByEmail/" + email
            });
        }
    }
}
