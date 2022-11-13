using TestWebAPI.DTOS.Person;

namespace TestWebAPI.DTOS.Book
{
    public class AddBookBorrowRequest
    {
        public List<int> BooksId { get; set; }
        public PersonModel Requester { get; set; }
    }
}
