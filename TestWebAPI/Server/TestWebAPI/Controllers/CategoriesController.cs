using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOS.Book;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public ActionResult<AddCategoryRespone> Add([FromBody] AddCategoryRequest addCategoryRequest)
        {
            try
            {
                var data = _categoryService.Add(addCategoryRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GetCategoryRespone> GetOne(int id)
        {
            {
                try
                {
                    var data = _categoryService.GetOne(id);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);

                }
            }
        }

        [HttpGet]
        public ActionResult<GetCategoryRespone> GetAll()
        {
            {
                try
                {
                    var data = _categoryService.GetAll();

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);

                }
            }
        }

        [HttpPut]
        public ActionResult<GetCategoryRespone> Update([FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            try
            {
                var data = _categoryService.Update(updateCategoryRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = _categoryService.Delete(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
