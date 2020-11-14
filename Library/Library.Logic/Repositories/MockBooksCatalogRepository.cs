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
        private readonly MockDbContext dbContext;

        public MockBooksCatalogRepository(MockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Book> GetAllBooks()
        {
            return dbContext.Books();
        }

        public Book GetBookById(int id)
        {
            return dbContext.Books().FirstOrDefault(i => i.Id.Equals(id));
        }

        public Book GetBookByType(BookEnum bookType)
        {
            return dbContext.Books().FirstOrDefault(t => t.BookType.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            Book deletedBook = dbContext.Books().FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null)
            {
                dbContext.Books().Remove(deletedBook);
            }
        }

        public void EditBook(Book book)
        {
            Book editedBook = dbContext.Books().FirstOrDefault(b => b.Id.Equals(book.Id));

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

            dbContext.Books().Add(addedBook);
        }
    }
}
