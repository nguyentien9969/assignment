using Enitity_Framework.Models;
using Enitity_Framework.Data;

namespace Enitity_Framework.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context)
        {
        }
    }
}