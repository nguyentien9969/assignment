using System.Text.Json.Serialization;
using TestWebAPI.DTOS.Person;

namespace TestWebAPI.DTOS.Book
{
    public class ApproveBookBorrowRequestRequest
    {
        public int? Id { get; set; }
        public bool IsApproved { get; set; }
        public PersonModel? Approver { get; set; }
    }
}
