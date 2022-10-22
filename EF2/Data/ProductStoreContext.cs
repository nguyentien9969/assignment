using EF2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF2.Data
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.Id)
                            .HasColumnName("CatId")
                            .HasColumnType("int")
                            .IsRequired()
                            .UseIdentityColumn();
            modelBuilder.Entity<Category>()
                            .ToTable("Category")
                            .HasKey(cat => cat.Id);
            modelBuilder.Entity<Category>()
                            .HasMany(c => c.Products)
                            .WithOne(p => p.Category)
                            .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.Name)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                            .HasOne<Category>(s => s.Category)
                            .WithMany(p => p.Products)
                            .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                            .Property(p => p.Id)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .IsRequired()
                            .UseIdentityColumn();
            modelBuilder.Entity<Product>()
                            .Property(p => p.Name)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);
            modelBuilder.Entity<Product>()
                            .Property(p => p.Manufacture)
                            .HasColumnName("ProductManufacture")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);
            modelBuilder.Entity<Product>()
                            .Property(p => p.CategoryId)
                            .HasColumnName("ProductCategoryId")
                            .HasColumnType("int");

            // Seeding
            modelBuilder.Entity<Category>()
                            .HasData(
                                new Category
                                {
                                    Id = 1,
                                    Name = "Computer",
                                },
                                new Category
                                {
                                    Id = 2,
                                    Name = "Mouse",
                                },
                                new Category
                                {
                                    Id = 3,
                                    Name = "Screen",
                                }
                            );
            modelBuilder.Entity<Product>()
                            .HasData(
                            new Product
                            {
                                Id = 1,
                                Name = "A1",
                                Manufacture = "VietNam",
                                CategoryId = 1,
                            },
                              new Product
                              {
                                  Id = 2,
                                  Name = "A2",
                                  Manufacture = "China",
                                  CategoryId = 1,
                              },
                              new Product
                              {
                                  Id = 3,
                                  Name = "A3",
                                  Manufacture = "China",
                                  CategoryId = 2,
                              },
                              new Product
                              {
                                  Id = 4,
                                  Name = "B4",
                                  Manufacture = "China",
                                  CategoryId = 2,
                              },
                            new Product
                            {
                                Id = 5,
                                Name = "B4",
                                Manufacture = "China",
                                CategoryId = 3,
                            }
                            );
        }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

    }
}