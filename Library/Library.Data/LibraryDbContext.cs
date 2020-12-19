using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\BARTEKSQL;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BookCatalog> BookCatalogs { get; set; }
        public virtual DbSet<BookState> BookStates { get; set; }
        public virtual DbSet<RentalEvent> RentalEvents { get; set; }
        public virtual DbSet<ReturnEvent> ReturnEvents { get; set; }
    }
}