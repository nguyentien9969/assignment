namespace TestWebAPI.DTOS.Book
{
    public class AddBookBorrowRespone
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int? RequestedBy { get; set; }
        public DateTime RequestedAt { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
