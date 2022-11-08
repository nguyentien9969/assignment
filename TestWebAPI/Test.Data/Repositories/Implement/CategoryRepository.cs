using Test.Data.Entities;
using Test.Data.Repositories.Interface;

namespace Test.Data.Repositories.Implement
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryContext context) : base(context)
        {
        }
    }
}