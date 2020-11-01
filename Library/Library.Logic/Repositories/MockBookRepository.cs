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
        private List<Book> books;

        public MockBookRepository()
        {
            books = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, Amount = 3, IsAvailable = true, RentalDate = default, GiveBackDate = default},
                new Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman, Amount = 1, IsAvailable = true, RentalDate = default, GiveBackDate = default},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, Amount = 0, IsAvailable = false, RentalDate = default, GiveBackDate = default},
            };
        }

        public IQueryable<Book> GetAllBooks()
        {
            return books.AsQueryable();
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(i => i.Id.Equals(id));
        }

        public Book GetBookByType(BookEnum bookType)
        {
            return books.FirstOrDefault(t => t.BookType.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            Book deletedBook = books.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null)
            {
                books.Remove(deletedBook);
            }
        }

        public void EditBook(Book book)
        {
            Book editedBook = books.FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                editedBook.Title = book.Title;
                editedBook.BookType = book.BookType;
                editedBook.Amount = book.Amount;
                editedBook.IsAvailable = book.IsAvailable;
                editedBook.RentalDate = book.RentalDate;
            }
        }

        public void AddBook(Book book)
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

            books.Add(addedBook);
        }
    }
}
