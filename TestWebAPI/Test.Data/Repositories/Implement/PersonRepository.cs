using Test.Data.Entities;
using Test.Data.Repositories.Interface;

namespace Test.Data.Repositories.Implement
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(LibraryContext context)
            : base(context)
        {
        }
    }
}
