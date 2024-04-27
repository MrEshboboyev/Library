using Library.Web.Models;
using Library.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
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

        [Authorize]
        public async Task<IActionResult> BookIndex()
        {
            return View(await LoadBooksBasedOnLoggedInUser());
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
                model.UserId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault().Value;

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

        // private methods
        private async Task<List<BookDto>> LoadBooksBasedOnLoggedInUser()
        {
            // getting user id
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault().Value;

            // getting response from Backend
            ResponseDto? response = await _bookService.GetBooksByUserIdAsync(userId);

            if(response != null && response.IsSuccess)
            {
                // deserialize response for List<BookDto>
                List<BookDto> bookDtos = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Result));

                return bookDtos;
            }

            return new List<BookDto>();
        }
    }
}
