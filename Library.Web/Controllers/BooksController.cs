using Library.Web.Models;
using Library.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BookIndex()
        {
            List<BookDto> list = new();
            ResponseDto? response = await _bookService.GetAllBooksAsync();
            if (response.IsSuccess && response != null)
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult BookCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(BookDto model)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _bookService.CreateBookAsync(model);
                if (response.IsSuccess && response != null)
                {
                    TempData["success"] = "Book successfully created!";

                    return RedirectToAction(nameof(BookIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookEdit(int id)
        {
            BookDto bookDto = new();
            ResponseDto? response = await _bookService.GetBookByIdAsync(id);
            if (response.IsSuccess && response != null)
            {
                bookDto = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Result));
                return View(bookDto);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookEdit(BookDto model)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _bookService.UpdateBookAsync(model);
                if (response.IsSuccess && response != null)
                {
                    TempData["success"] = "Book successfully updated!";

                    return RedirectToAction(nameof(BookIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookDelete(int id)
        {
            BookDto bookDto = new();
            ResponseDto? response = await _bookService.GetBookByIdAsync(id);
            if (response.IsSuccess && response != null)
            {
                bookDto = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Result));
                return View(bookDto);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View();
        }

        [HttpPost]
        [ActionName("BookDelete")]
        public async Task<IActionResult> BookDeletePOST(int id)
        {
            ResponseDto? response = await _bookService.DeleteBookAsync(id);
            if (response.IsSuccess && response != null)
            {
                TempData["success"] = "Book successfully deleted!";

                return RedirectToAction(nameof(BookIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View();
        }
    }
}
