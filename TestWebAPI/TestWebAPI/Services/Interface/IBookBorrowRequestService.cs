using Test.Data.Entities;
using TestWebAPI.DTOS.Book;

namespace TestWebAPI.Services.Interface
{
    public interface IBookBorrowRequestService
    {
        AddBookBorrowRespone Add(AddBookBorrowRequest request);
        GetBookBorrowRequestRespone GetById(int id);
        IEnumerable<BookBorrowRequest> GetAll();
        ApproveBookBorrowRequestRespone Approve(ApproveBookBorrowRequestRequest request);
        string CheckRequestLimit(AddBookBorrowRequest request);
    }
}
