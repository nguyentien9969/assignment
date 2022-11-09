using TestWebAPI.DTOS.Person;

namespace TestWebAPI.DTOS.Book
{
    public class ApproveBookBorrowRequestRespone
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public PersonModel Requester { get; set; }
        public DateTime RequestedAt { get; set; }
        public PersonModel Approver { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
