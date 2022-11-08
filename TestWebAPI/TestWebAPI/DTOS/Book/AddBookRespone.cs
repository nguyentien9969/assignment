using System.ComponentModel.DataAnnotations;
using TestWebAPI.DTOS.Category;

namespace TestWebAPI.DTOS.Book
{
    public class AddBookRespone
    {
        public string Name { get; set; }
        public string Description { get; set; }  
        public List<CategoryModel> Categories { get; set; }
    }
}
