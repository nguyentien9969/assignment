using Test.Data.Entities;
using TestWebAPI.DTOS.Book;

namespace TestWebAPI.Services.Interface
{
    public interface IBookService
    {
        AddBookRespone AddBook (AddBookRequest request);
        GetBookRespone GetBook(int id);
        UpdateBookRespone UpdateBook (UpdateBookRequest request);
        bool DeleteBook (int id);
        IEnumerable<GetBookRespone> GetAll();
    }
}
