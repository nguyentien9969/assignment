namespace EF2.DTOs
{
    public class UpdateProductRequest
    {
        public string Name { get; set; } = null!;
        public string Manufacture { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}