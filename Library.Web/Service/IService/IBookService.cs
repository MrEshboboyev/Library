using Library.Web.Models;

namespace Library.Web.Service.IService
{
    public interface IBookService
    {
        Task<ResponseDto?> GetBooksByUserIdAsync(string userId);
        Task<ResponseDto?> GetAllBooksAsync();
        Task<ResponseDto?> GetBookByIdAsync(int id);
        Task<ResponseDto?> CreateBookAsync(BookDto bookDto);
        Task<ResponseDto?> UpdateBookAsync(BookDto bookDto);
        Task<ResponseDto?> DeleteBookAsync(int id);
    }
}
