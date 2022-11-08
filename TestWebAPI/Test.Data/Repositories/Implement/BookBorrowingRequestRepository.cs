using Test.Data.Entities;
using Test.Data.Repositories.Interface;

namespace Test.Data.Repositories.Implement
{
    public class BookBorrowRequestRepository : BaseRepository<BookBorrowRequest>, IBookBorrowRequestRepository
    {
        public BookBorrowRequestRepository(LibraryContext context) : base(context)
        {
        }
    }
}