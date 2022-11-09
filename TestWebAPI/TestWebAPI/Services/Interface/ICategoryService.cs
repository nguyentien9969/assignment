using TestWebAPI.DTOS.Book;

namespace TestWebAPI.Services.Interface
{
    public interface ICategoryService
    {
        AddCategoryRespone Add(AddCategoryRequest request);
        GetCategoryRespone GetOne(int id);
        IEnumerable<GetCategoryRespone> GetAll();
        UpdateCategoryRespone Update(UpdateCategoryRequest request);
        bool Delete(int id);
    }
}
