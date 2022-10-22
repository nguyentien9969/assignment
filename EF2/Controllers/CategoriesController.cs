using EF2.Services;
using Microsoft.AspNetCore.Mvc;
using EF2.DTOs.Category;

namespace EF2.Controllers;


[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService CategoriesService)
    {
        _categoryService = CategoriesService;
    }

    [HttpGet]
    public IEnumerable<GetCategoryRespone> GetAll()
    {
        return _categoryService.GetAll();
    }

    [HttpGet("{id}")]
    public GetCategoryRespone GetById(int id)
    {
        return _categoryService.GetById(id);
    }

    [HttpPost]
    public AddCategoryRespone Add([FromBody] AddCategoryRequest requestModel)
    {
        return _categoryService.Create(requestModel);
    }

    [HttpPut("{id}")]
    public UpdateCategoryRespone Update(int id, [FromBody] UpdateCategoryRequest requestModel)
    {
        return _categoryService.Update(id, requestModel);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _categoryService.Delete(id);
    }
}
