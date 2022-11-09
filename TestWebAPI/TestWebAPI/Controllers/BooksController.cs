using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOS.Book;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public ActionResult<AddBookRespone> AddBook([FromBody] AddBookRequest addBookRequest)
        {
            {
                try
                {
                    var data = _bookService.AddBook(addBookRequest);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpGet]
        public ActionResult<GetBookRespone> GetAll()
        {
            {
                try
                {
                    var data = _bookService.GetAll();

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            {
                try
                {
                    var data = _bookService.GetBook(id);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<GetBookRespone> Delete(int id)
        {
            try
            {
                var data = _bookService.DeleteBook(id);

                if (!data) return BadRequest(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<UpdateBookRespone> Update([FromBody] UpdateBookRequest updateBookRequest)
        {
            try
            {
                var data = _bookService.UpdateBook(updateBookRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

