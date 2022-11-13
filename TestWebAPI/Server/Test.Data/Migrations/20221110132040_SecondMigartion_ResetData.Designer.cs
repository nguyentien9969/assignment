﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Data;

#nullable disable

namespace Test.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20221110132040_SecondMigartion_ResetData")]
    partial class SecondMigartion_ResetData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookBookBorrowRequest", b =>
                {
                    b.Property<int>("BookBorrowRequestsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("BookBorrowRequestsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("BookBorrowRequestDetails", (string)null);

                    b.HasData(
                        new
                        {
                            BookBorrowRequestsId = 1,
                            BooksId = 1
                        },
                        new
                        {
                            BookBorrowRequestsId = 1,
                            BooksId = 2
                        });
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("BookCategories", (string)null);

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            CategoriesId = 1
                        },
                        new
                        {
                            BooksId = 2,
                            CategoriesId = 2
                        },
                        new
                        {
                            BooksId = 3,
                            CategoriesId = 2
                        },
                        new
                        {
                            BooksId = 4,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 5,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 6,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 3,
                            CategoriesId = 1
                        },
                        new
                        {
                            BooksId = 4,
                            CategoriesId = 2
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Conan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Doraemon"
                        },
                        new
                        {
                            Id = 3,
                            Name = "GT1"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Phan tich thiet ke"
                        },
                        new
                        {
                            Id = 5,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.BookBorrowRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ApproveAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AprovedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<int?>("RequestedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AprovedBy");

                    b.HasIndex("RequestedBy");

                    b.ToTable("BookBorrowRequest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApproveAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequestAt = new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(175),
                            RequestStatus = 0,
                            RequestedBy = 1
                        },
                        new
                        {
                            Id = 2,
                            ApproveAt = new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(185),
                            AprovedBy = 3,
                            RequestAt = new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(185),
                            RequestStatus = 1,
                            RequestedBy = 1
                        },
                        new
                        {
                            Id = 3,
                            ApproveAt = new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(187),
                            AprovedBy = 4,
                            RequestAt = new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(186),
                            RequestStatus = 2,
                            RequestedBy = 2
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Comic"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nguyen Tien",
                            Password = "pass1",
                            Role = 0,
                            Username = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bui Ngoc",
                            Password = "pass2",
                            Role = 0,
                            Username = "user2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ngoc Anh",
                            Password = "pass3",
                            Role = 1,
                            Username = "user3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Anh Tuan",
                            Password = "pass4",
                            Role = 1,
                            Username = "user4"
                        });
                });

            modelBuilder.Entity("BookBookBorrowRequest", b =>
                {
                    b.HasOne("Test.Data.Entities.BookBorrowRequest", null)
                        .WithMany()
                        .HasForeignKey("BookBorrowRequestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("Test.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Data.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test.Data.Entities.BookBorrowRequest", b =>
                {
                    b.HasOne("Test.Data.Entities.Person", "Approver")
                        .WithMany("BookApprovedBorrowRequests")
                        .HasForeignKey("AprovedBy");

                    b.HasOne("Test.Data.Entities.Person", "Requester")
                        .WithMany("BookRequestedBorrowRequests")
                        .HasForeignKey("RequestedBy");

                    b.Navigation("Approver");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("Test.Data.Entities.Person", b =>
                {
                    b.Navigation("BookApprovedBorrowRequests");

                    b.Navigation("BookRequestedBorrowRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
