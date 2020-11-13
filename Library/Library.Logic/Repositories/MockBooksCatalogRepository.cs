using Library.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Logic.Repositories
{
    public class MockBooksCatalogRepository : IBooksCatalogRepository
    {
        private BooksCatalog bookCatalog = new BooksCatalog();

        public MockBooksCatalogRepository()
        {
            bookCatalog.Books = new List<Book>
            {
                new Book { Id = 1, Title = "aaaa", BookType = BookEnum.Adventure },
                new Book { Id = 2, Title = "bbbb", BookType = BookEnum.Roman },
                new Book { Id = 3, Title = "cccc", BookType = BookEnum.Document },
                new Book { Id = 4, Title = "dddd", BookType = BookEnum.Adventure },
                new Book { Id = 5, Title = "eeee", BookType = BookEnum.Roman },
                new Book { Id = 6, Title = "ffff", BookType = BookEnum.Document }
            };
        }

        public List<Book> GetAllBooks()
        {
            return bookCatalog.Books;
        }

        public Book GetBookById(int id)
        {
            return bookCatalog.Books.FirstOrDefault(i => i.Id.Equals(id));
        }

        public Book GetBookByType(BookEnum bookType)
        {
            return bookCatalog.Books.FirstOrDefault(t => t.BookType.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            Book deletedBook = bookCatalog.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null)
            {
                bookCatalog.Books.Remove(deletedBook);
            }
        }

        public void EditBook(Book book)
        {
            Book editedBook = bookCatalog.Books.FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                editedBook.Title = book.Title;
                editedBook.BookType = book.BookType;
            }
        }

        public void AddBook(Book book)
        {
            Book addedBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                BookType = book.BookType,
            };

            bookCatalog.Books.Add(addedBook);
        }
    }
}
