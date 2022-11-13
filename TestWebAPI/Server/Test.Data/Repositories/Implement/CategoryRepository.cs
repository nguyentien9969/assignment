using System.Linq.Expressions;
using System.Linq;
using Test.Data.Entities;
using Test.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Repositories.Implement
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryContext context) : base(context)
        {
        }
        public override IEnumerable<Category> GetAllWithPredicate(Expression<Func<Category, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet.Include(cat => cat.Books).ToList();
        }
    }
}