using AutoMapper;
using Library.Services.AuthAPI.Data;
using Library.Services.AuthAPI.Models;
using Library.Services.AuthAPI.Models.Dto;
using Library.Services.AuthAPI.Service.IService;

namespace Library.Services.AuthAPI.Service
{
    public class UserService : IUserService
    {
        // DI for Database
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public UserService(AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            try
            {
                IEnumerable<UserDto> users = _mapper.Map<IEnumerable<UserDto>>(_db.ApplicationUsers.ToList());

                return users;
            }
            catch (Exception ex)
            {
            }

            return new List<UserDto>();
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            try
            {
                UserDto user = _mapper.Map<UserDto>(_db.ApplicationUsers.FirstOrDefault(user => 
                    user.Email.ToLower() == email.ToLower()));

                if (user == null)
                    throw new Exception($"User with email '{email}' not found.");
                    

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
