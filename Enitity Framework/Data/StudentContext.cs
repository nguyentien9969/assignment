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
                    // modelBuilder.Entity<Product>()
                    //                     .HasData(new Product
                    //                     {

                    //                     });
                    
        }
        public DbSet<Student> Students { get; set; } = null!;
    }
}