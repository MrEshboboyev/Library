using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Services.BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Description", "Genre", "Language", "Name", "Rating", "Size" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "A story about the American Dream.", "Classic", "English", "The Great Gatsby", 4.5, 250 },
                    { 2, "Harper Lee", "A powerful story of racial injustice and the loss of innocence.", "Fiction", "English", "To Kill a Mockingbird", 4.7999999999999998, 320 },
                    { 3, "George Orwell", "A dystopian social science fiction novel.", "Dystopian", "English", "1984", 4.7000000000000002, 328 },
                    { 4, "Jane Austen", "A romantic novel of manners.", "Romance", "English", "Pride and Prejudice", 4.5999999999999996, 432 },
                    { 5, "J.D. Salinger", "A novel about teenage angst and alienation.", "Literary Fiction", "English", "The Catcher in the Rye", 4.4000000000000004, 277 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
