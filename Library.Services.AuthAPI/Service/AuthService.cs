using Library.Services.AuthAPI.Data;
using Library.Services.AuthAPI.Models;
using Library.Services.AuthAPI.Models.Dto;
using Library.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Library.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db; 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == user.Email);

                    UserDto userDto = new()
                    {
                        Email = user.Email,
                        Name = userToReturn.FirstName + " " + userToReturn.LastName,
                        PhoneNumber = userToReturn.PhoneNumber,
                        Id = userToReturn.Id
                    };

                    return userDto;
                }
            }
            catch (Exception ex)
            {
            }

            return new UserDto();
        }
    }
}
