using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DTOS.Book
{
    public class AddBookRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public List<int> CategoryIds { get; set; }
    }
}
