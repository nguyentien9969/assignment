using Test.Data.Entities;
using Test.Data.Repositories.Interface;

namespace Test.Data.Repositories.Implement
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}