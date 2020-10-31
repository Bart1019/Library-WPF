using Library.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockBookRepository : IBookRepository
    {
        private List<Book> _books;

        public MockBookRepository()
        {
            _books = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, Amount = 3, IsAvailable = true, RentalDate = default},
                new Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman, Amount = 1, IsAvailable = true, RentalDate = default},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, Amount = 0, IsAvailable = false, RentalDate = default},
            };
        }

        public IQueryable<Book> GetAll()
        {
            return _books.AsQueryable();
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(i => i.Id.Equals(id));
        }

        public Book GetByType(BookEnum bookType)
        {
            return _books.FirstOrDefault(t => t.BookType.Equals(bookType));
        }

        public void Delete(int id)
        {
            Book deletedBook = _books.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null)
            {
                _books.Remove(deletedBook);
            }
        }

        public void Edit(Book book)
        {
            Book editedBook = _books.FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                if (book.Title != null)
                {
                    editedBook.Title = book.Title;
                }

                editedBook.BookType = book.BookType;
                editedBook.Amount = book.Amount;
                editedBook.IsAvailable = book.IsAvailable;
                editedBook.RentalDate = book.RentalDate;
            }
        }

        public void Add(Book book)
        {
            Book addedBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                BookType = book.BookType,
                Amount = book.Amount,
                IsAvailable = book.IsAvailable,
                RentalDate = book.RentalDate
            };

            _books.Add(addedBook);
        }
    }
}
