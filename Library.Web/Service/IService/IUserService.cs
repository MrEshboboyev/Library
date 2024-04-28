using Library.Web.Models;

namespace Library.Web.Service.IService
{
    public interface IUserService
    {
        Task<ResponseDto?> GetUsersAsync();
        Task<ResponseDto?> GetUserByEmailAsync(string email);
    }
}
