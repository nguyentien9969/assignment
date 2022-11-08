using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
