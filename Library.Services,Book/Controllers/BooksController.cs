using AutoMapper;
using Library.Services_Book.Data;
using Library.Services_Book.Models;
using Library.Services_Book.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Services_Book.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // DI for database
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _response;
        public BooksController(AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _response = new();
            _mapper = mapper;
        }

        // get books
        [HttpGet]
        public ResponseDto? Get()
        {
            try
            {
                IEnumerable<Book> objList = _db.Books.ToList();

                _response.Result = _mapper.Map<IEnumerable<BookDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        // get book by id
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto? Get(int id)
        {
            try
            {
                Book obj = _db.Books.First(b => b.BookId == id);

                _response.Result = _mapper.Map<BookDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        public ResponseDto? Post([FromBody] BookDto bookDto)
        {
            try
            {
                Book obj = _mapper.Map<Book>(bookDto);

                _db.Books.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<BookDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        public ResponseDto? Put([FromBody] BookDto bookDto)
        {
            try
            {
                Book obj = _mapper.Map<Book>(bookDto);

                _db.Books.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<BookDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto? Delete(int id)
        {
            try
            {
                Book obj = _db.Books.First(b => b.BookId == id);

                _db.Books.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
