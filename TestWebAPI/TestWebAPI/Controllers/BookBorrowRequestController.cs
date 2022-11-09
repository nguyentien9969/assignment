using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOS.Book;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookBorrowRequestController : ControllerBase
    {
        private readonly IBookBorrowRequestService _borrowRequestService;

        public BookBorrowRequestController(IBookBorrowRequestService _bookBorrowRequestService)
        {
            _borrowRequestService = _bookBorrowRequestService;
        }

        [HttpGet]
        public ActionResult<GetBookBorrowRequestRespone> GetAll()
        {
            try
            {
                var data = _borrowRequestService.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GetBookBorrowRequestRespone> GetById(int id)
        {
            try
            {
                var data = _borrowRequestService.GetById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Approve")]
        public ActionResult<ApproveBookBorrowRequestRespone> Approve([FromBody] ApproveBookBorrowRequestRequest request)
        {
            try
            {
                var data = _borrowRequestService.Approve(request);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<AddBookBorrowRespone> Add([FromBody] AddBookBorrowRequest request)
        {
            try
            {
                var checkLimit = _borrowRequestService.CheckRequestLimit(request);

                if (request == null) return BadRequest(checkLimit);

                var data = _borrowRequestService.Add(request);

                if (data == null) return BadRequest(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
