using Microsoft.EntityFrameworkCore;
using Enitity_Framework.Models;

namespace Enitity_Framework.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
        {
        }
        public DbSet<Student> Students { get; set; } = null!;
    }
}