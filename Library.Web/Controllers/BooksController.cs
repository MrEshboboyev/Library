using Library.Web.Models;
using Library.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private ResponseDto? _response;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
            _response = new();
        }

        public async Task<IActionResult> Index()
        {
            _response = await _bookService.GetAllBooksAsync();
            if (_response.IsSuccess && _response != null)
            {
                IEnumerable<BookDto> objList = JsonConvert.DeserializeObject<IEnumerable<BookDto>>((_response.Result).ToString());

                return View(objList);
            }

            return View();
        }
    }
}
