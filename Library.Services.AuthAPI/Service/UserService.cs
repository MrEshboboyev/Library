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

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            try
            {
                IEnumerable<ApplicationUser> users = _db.ApplicationUsers.ToList();

                return users;
            }
            catch (Exception ex)
            {
            }

            return new List<ApplicationUser>();
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            try
            {
                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(user => user.Email.ToLower() == email.ToLower());

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
