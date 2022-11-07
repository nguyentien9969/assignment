 using Test.Data.Entities;
 using Microsoft.EntityFrameworkCore;

 namespace Test.Data
{   public class BookContext : DbContext
    {
         public BookContext(DbContextOptions<BookContext> options) : base(options)
         {

       }
         public DbSet<Person> People { get; set; }
         public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; } = null!;
         public DbSet<BookeBorrowingRequestDetails> BookeBorrowingRequestDetails { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
     }
 }