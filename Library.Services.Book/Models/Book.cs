using System.ComponentModel.DataAnnotations;

namespace Library.Services.BookAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}
