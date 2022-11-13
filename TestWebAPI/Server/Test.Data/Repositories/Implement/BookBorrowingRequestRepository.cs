using System.Linq.Expressions;
using System.Linq;
using Test.Data.Entities;
using Test.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Repositories.Implement
{
    public class BookBorrowRequestRepository : BaseRepository<BookBorrowRequest>, IBookBorrowRequestRepository
    {
        public BookBorrowRequestRepository(LibraryContext context) : base(context)
        {
        }
        public override IEnumerable<BookBorrowRequest> GetAllWithPredicate(Expression<Func<BookBorrowRequest, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet
                    .Include(br => br.Requester)
                    .Include(br => br.Approver)
                    .Include(br => br.Books)
                    .ToList();
        }
    }
}