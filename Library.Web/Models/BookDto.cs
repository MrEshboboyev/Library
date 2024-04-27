namespace Library.Web.Models
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public double Rating { get; set; }
    }
}
