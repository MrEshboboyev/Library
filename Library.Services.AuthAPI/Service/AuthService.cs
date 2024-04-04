using Library.Services.AuthAPI.Models.Dto;
using Library.Services.AuthAPI.Service.IService;

namespace Library.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
