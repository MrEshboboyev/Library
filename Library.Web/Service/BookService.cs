using Library.Web.Models;
using Library.Web.Service.IService;
using Library.Web.Utility;
using static Library.Web.Utility.SD;

namespace Library.Web.Service
{
    public class BookService : IBookService
    {
        private readonly IBaseService _baseService;
        public BookService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateBookAsync(BookDto bookDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.POST,
                Data = bookDto,
                Url = SD.BookAPIBase + "/api/book"
            });
        }

        public async Task<ResponseDto?> DeleteBookAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.DELETE,
                Url = SD.BookAPIBase + "/api/book/" + id
            });
        }

        public async Task<ResponseDto?> GetAllBooksAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.BookAPIBase + "/api/book"
            });
        }

        public async Task<ResponseDto?> GetBookByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.BookAPIBase + "/api/book/" + id
            });
        }

        public async Task<ResponseDto?> UpdateBookAsync(BookDto bookDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.PUT,
                Data = bookDto,
                Url = SD.BookAPIBase + "/api/book"
            });
        }
    }
}
