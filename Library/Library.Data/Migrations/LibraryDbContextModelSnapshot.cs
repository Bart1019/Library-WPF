﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookCatalogCatalogId")
                        .HasColumnType("int");

                    b.Property<int>("BookGenre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookCatalogCatalogId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Data.BookCatalog", b =>
                {
                    b.Property<int>("CatalogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CatalogId");

                    b.ToTable("BookCatalogs");
                });

            modelBuilder.Entity("Library.Data.BookState", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AllBooksCatalogId")
                        .HasColumnType("int");

                    b.Property<int?>("AvailableBooksDictionaryId")
                        .HasColumnType("int");

                    b.HasKey("StateId");

                    b.HasIndex("AllBooksCatalogId");

                    b.HasIndex("AvailableBooksDictionaryId");

                    b.ToTable("BookStates");
                });

            modelBuilder.Entity("Library.Data.Models.BookDictionary", b =>
                {
                    b.Property<int>("DictionaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BooksAmount")
                        .HasColumnType("int");

                    b.HasKey("DictionaryId");

                    b.HasIndex("BookId");

                    b.ToTable("BookDictionary");
                });

            modelBuilder.Entity("Library.Data.RentalEvent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("RentalEvents");
                });

            modelBuilder.Entity("Library.Data.ReturnEvent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("ReturnEvents");
                });

            modelBuilder.Entity("Library.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOfBooksRented")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Library.Data.Book", b =>
                {
                    b.HasOne("Library.Data.BookCatalog", null)
                        .WithMany("Books")
                        .HasForeignKey("BookCatalogCatalogId");
                });

            modelBuilder.Entity("Library.Data.BookState", b =>
                {
                    b.HasOne("Library.Data.BookCatalog", "AllBooks")
                        .WithMany()
                        .HasForeignKey("AllBooksCatalogId");

                    b.HasOne("Library.Data.Models.BookDictionary", "AvailableBooks")
                        .WithMany()
                        .HasForeignKey("AvailableBooksDictionaryId");
                });

            modelBuilder.Entity("Library.Data.Models.BookDictionary", b =>
                {
                    b.HasOne("Library.Data.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("Library.Data.RentalEvent", b =>
                {
                    b.HasOne("Library.Data.BookState", "BookInLibrary")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Data.User", "RentalUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Data.ReturnEvent", b =>
                {
                    b.HasOne("Library.Data.BookState", "BookInLibrary")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Data.User", "RentalUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
