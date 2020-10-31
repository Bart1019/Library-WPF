using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockLibraryRepository : ILibraryRepository
    {
        private List<Book> _books;

        public MockLibraryRepository()
        {
            _books = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, Amount = 3, IsAvailable = true, RentalDate = default},
                new Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman, Amount = 1, IsAvailable = true, RentalDate = default},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, Amount = 5, IsAvailable = false, RentalDate = default},
                new Book {Id = 4, Title = "dddd", BookType = BookEnum.Historic, Amount = 7, IsAvailable = true, RentalDate = default},
                new Book {Id = 5, Title = "eeee", BookType = BookEnum.SciFi, Amount = 1, IsAvailable = false, RentalDate = default},
                new Book {Id = 6, Title = "ffff", BookType = BookEnum.Document, Amount = 0, IsAvailable = false, RentalDate = default},
            };
        }

        public IQueryable<Book> GetAllAvailableBooks()
        {
            return _books.Where(x => x.IsAvailable.Equals(true)).AsQueryable();
        }

        public IQueryable<Book> GetAllUnavailableBooks()
        {
            return _books.Where(x => x.IsAvailable.Equals(false)).AsQueryable();
        }
    }
}
