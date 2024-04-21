using Library.Services.AuthAPI.Models;

namespace Library.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles); 
    }
}
