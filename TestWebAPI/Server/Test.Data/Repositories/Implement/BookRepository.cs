using System.Linq.Expressions;
using System.Linq;
using Test.Data.Entities;
using Test.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Repositories.Implement
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
        public IEnumerable<Book> GetAllWithPredicate(Expression<Func<Book, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return  dbSet.Include(book => book.Categories).ToList();
        }
    }
}