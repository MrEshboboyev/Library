using Library.Services_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services_Book.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Name = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Classic",
                    Size = 250,
                    Description = "A story about the American Dream.",
                    Language = "English",
                    Rating = 4.5
                },
                new Book
                {
                    BookId = 2,
                    Name = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    Size = 320,
                    Description = "A powerful story of racial injustice and the loss of innocence.",
                    Language = "English",
                    Rating = 4.8
                },
                new Book
                {
                    BookId = 3,
                    Name = "1984",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    Size = 328,
                    Description = "A dystopian social science fiction novel.",
                    Language = "English",
                    Rating = 4.7
                },
                new Book
                {
                    BookId = 4,
                    Name = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Genre = "Romance",
                    Size = 432,
                    Description = "A romantic novel of manners.",
                    Language = "English",
                    Rating = 4.6
                },
                new Book
                {
                    BookId = 5,
                    Name = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Genre = "Literary Fiction",
                    Size = 277,
                    Description = "A novel about teenage angst and alienation.",
                    Language = "English",
                    Rating = 4.4
                }
                );
        }
    }
}
