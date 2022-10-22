using EF2.DTOs.Category;

namespace EF2.Services
{
    public interface ICategoryService
    {
        IEnumerable<GetCategoryRespone> GetAll();
        GetCategoryRespone GetById(int id);
        AddCategoryRespone Create(AddCategoryRequest requestModel);
        UpdateCategoryRespone Update(int id, UpdateCategoryRequest requestModel);
        bool Delete(int id);
    }
}