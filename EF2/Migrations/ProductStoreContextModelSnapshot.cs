﻿// <auto-generated />
using EF2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF2.Migrations
{
    [DbContext(typeof(ProductStoreContext))]
    partial class ProductStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EF2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CatId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mouse"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Screen"
                        });
                });

            modelBuilder.Entity("EF2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("ProductCategoryId");

                    b.Property<string>("Manufacture")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("ProductManufacture");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("ProductName");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Manufacture = "VietNam",
                            Name = "A1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Manufacture = "China",
                            Name = "A2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Manufacture = "China",
                            Name = "A3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Manufacture = "China",
                            Name = "B4"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Manufacture = "China",
                            Name = "B4"
                        });
                });

            modelBuilder.Entity("EF2.Models.Product", b =>
                {
                    b.HasOne("EF2.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EF2.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
