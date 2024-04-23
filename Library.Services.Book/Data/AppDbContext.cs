using Microsoft.EntityFrameworkCore;
using Library.Services.BookAPI.Models;

namespace Library.Services.BookAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
