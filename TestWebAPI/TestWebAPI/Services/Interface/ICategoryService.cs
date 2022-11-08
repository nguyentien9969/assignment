using TestWebAPI.DTOS.Book;
using TestWebAPI.DTOS.Category;

namespace TestWebAPI.Services.Interface
{
    public interface ICategoryService
    {
        AddCategoryRespone AddBook(AddCategoryRequest request);
        GetCategoryRespone GetBook(int id);
        IEnumerable<GetCategoryRespone> GetAllBook();
        UpdateCategoryRespone UpdateBook(UpdateCategoryRequest request);
        bool DeleteBook(int id);
    }
}
