using Common.Enums;

using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    [Table("BookBorrowRequest")]
    public class BookBorrowRequest : BaseEntity
    {
        public RequestStatus RequestStatus { get; set; }
        public int? AprovedBy { get; set; }
        public int? RequestedBy { get; set; }
        public DateTime RequestAt { get; set; }
        public DateTime ApproveAt { get; set; }
        public Person? Approver { get; set; }
        public Person? Requester { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
