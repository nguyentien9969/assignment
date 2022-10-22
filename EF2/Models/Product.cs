namespace EF2.Models
{
    public class Product : BaseEntity<int>
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public int CategoryId { get; set; }
    }
}