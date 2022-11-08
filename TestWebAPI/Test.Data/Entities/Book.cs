using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    [Table("Book")]
    public class Book : BaseEntity
    {
        public Book()
        {
            this.Categories = new HashSet<Category>();
        }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<BookBorrowRequest> BookBorrowRequests { get; set; }
    }
}
