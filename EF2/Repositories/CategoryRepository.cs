using EF2.Repositories.Interfaces;
using EF2.Data;
using EF2.Models;
using Enitity_Framework.Repositories;

namespace EF2.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}