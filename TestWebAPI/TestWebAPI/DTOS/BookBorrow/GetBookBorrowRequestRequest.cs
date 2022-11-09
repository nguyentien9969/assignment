using TestWebAPI.DTOS.Person;

namespace TestWebAPI.DTOS.Book
{
    public class GetBookBorrowRequestRequest
    {
        public int id { get; set; }
        public PersonModel Requester { get; set; }
    }
}
