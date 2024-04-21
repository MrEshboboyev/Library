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
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            // finding user by 'UserName'
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.Username.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            // checking exists [user] and valid password
            if(!isValid || user == null)
            {
                return new LoginResponseDto() { User = null, Token = ""};
            }

            // if user was found, Generate JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            // create UserDto for return loginResponseDto
            UserDto userDto = new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new() 
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
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
                        Name = userToReturn.UserName,
                        PhoneNumber = userToReturn.PhoneNumber,
                        Id = userToReturn.Id
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
            }

            return "Error encountered";
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            // finding user
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if(user != null)
            {
                if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    // if role not exist, create new role
                    _roleManager.CreateAsync(new IdentityRole() { Name = roleName }).GetAwaiter().GetResult();
                }

                // add 'user' role for user
                 await _userManager.AddToRoleAsync(user, roleName);

                return true;
            }

            return false;
        }
    }
}
