namespace EF2.Models
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}