using Microsoft.AspNetCore.Identity;

namespace Library.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
 