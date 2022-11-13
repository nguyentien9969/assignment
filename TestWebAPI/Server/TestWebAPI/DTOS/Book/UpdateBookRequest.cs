using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DTOS.Book
{
    public class UpdateBookRequest
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
