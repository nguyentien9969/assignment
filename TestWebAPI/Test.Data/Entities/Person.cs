using Common.Enums;

namespace Test.Data.Entities
{
    public class Person : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Role Role { get; set; }
        public ICollection<BookBorrowRequest> BookRequestedBorrowRequests { get; set; } = null!;
        public ICollection<BookBorrowRequest> BookApprovedBorrowRequests { get; set; } = null!;
    }
}
