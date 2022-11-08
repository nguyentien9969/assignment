using TestWebAPI.DTOS.Category;

namespace TestWebAPI.DTOS.Book
{
    public class UpdateBookRespone
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryModel> categories { get; set; }
    }
}
