using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;

namespace Test.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookBorrowRequest> BookBorrowRequest { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>()
            .HasMany(u => u.BookRequestedBorrowRequests)
            .WithOne(br => br.Requester)
            .HasForeignKey(br => br.RequestedBy);

        builder.Entity<Person>()
            .HasMany(u => u.BookApprovedBorrowRequests)
            .WithOne(br => br.Approver)
            .HasForeignKey(br => br.AprovedBy);
        builder.Entity<Book>()
            .HasMany(b => b.Categories)
            .WithMany(c => c.Books)
            .UsingEntity(b => b.ToTable("BookCategories"));

        

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Comic" },
            new Category { Id = 2, Name = "Science" },
            new Category { Id = 3, Name = "Math" },
            new Category { Id = 4, Name = "Other" }
        );

        builder.Entity<Book>().HasData(
            new Book { Id = 1, Name = "Conan" },
            new Book { Id = 2, Name = "Doraemon" },
            new Book { Id = 3, Name = "GT1" },
            new Book { Id = 4, Name = "Phan tich thiet ke" },
            new Book { Id = 5, Name = "C#" },
            new Book { Id = 6, Name = "Java" }
        );

        builder.Entity<Book>()
            .HasMany(b => b.Categories)
            .WithMany(c => c.Books)
            .UsingEntity(b => b.HasData(
                new { BooksId = 1, CategoriesId = 1 },
                new { BooksId = 2, CategoriesId = 2 },
                new { BooksId = 3, CategoriesId = 2 },
                new { BooksId = 4, CategoriesId = 3 },
                new { BooksId = 5, CategoriesId = 3 },
                new { BooksId = 6, CategoriesId = 3 },
                new { BooksId = 3, CategoriesId = 1 },
                new { BooksId = 4, CategoriesId = 2 }
            ));

        builder.Entity<Person>().HasData(
            new Person { Id = 1, Username = "user1", Password = "pass1", Name = "Nguyen Tien", Role = Role.Normal },
            new Person { Id = 2, Username = "user2", Password = "pass2", Name = "Bui Ngoc", Role = Role.Normal },
            new Person { Id = 3, Username = "user3", Password = "pass3", Name = "Ngoc Anh", Role = Role.Super },
            new Person { Id = 4, Username = "user4", Password = "pass4", Name = "Anh Tuan", Role = Role.Super }
        );

        builder.Entity<BookBorrowRequest>().HasData(
            new BookBorrowRequest { Id = 1, RequestStatus = RequestStatus.Waiting, RequestedBy = 1, RequestAt = DateTime.Now },
            new BookBorrowRequest
            {
                Id = 2,
                RequestStatus = RequestStatus.Approved,
                RequestedBy = 1,
                RequestAt = DateTime.Now,
                AprovedBy = 3,
                ApproveAt = DateTime.Now
            },
            new BookBorrowRequest
            {
                Id = 3,
                RequestStatus = RequestStatus.Rejected,
                RequestedBy = 2,
                RequestAt = DateTime.Now,
                AprovedBy = 4,
                ApproveAt = DateTime.Now
            }
        );

        builder.Entity<Book>()
            .HasMany(b => b.BookBorrowRequests)
            .WithMany(bc => bc.Books)
            .UsingEntity(b => b.ToTable("BookBorrowRequestDetails").HasData(
                new { BooksId = 1, BookBorrowRequestsId = 1 },
                new { BooksId = 2, BookBorrowRequestsId = 1 }
               
                ));
    }
}