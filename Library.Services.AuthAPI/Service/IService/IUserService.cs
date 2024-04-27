using Library.Services.AuthAPI.Models;
using Library.Services.AuthAPI.Models.Dto;

namespace Library.Services.AuthAPI.Service.IService
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserByEmail(string email);
    }
}
