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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                       
        }
        public DbSet<Student> Students { get; set; } = null!;
        
    }
}