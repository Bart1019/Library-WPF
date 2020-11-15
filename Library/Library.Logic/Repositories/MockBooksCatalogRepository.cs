using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockBooksCatalogRepository : IBooksCatalogRepository
    {
        private readonly MockDbContext dbContext;

        public MockBooksCatalogRepository(MockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BooksCatalog.Book> GetAllBooks()
        {
            return dbContext.BooksCatalog();
        }

        public BooksCatalog.Book GetBookById(int id)
        {
            return dbContext.BooksCatalog().FirstOrDefault(i => i.Id.Equals(id));
        }

        public BooksCatalog.Book GetBookByType(BookEnum bookType)
        {
            return dbContext.BooksCatalog().FirstOrDefault(t => t.BookType.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            var deletedBook = dbContext.BooksCatalog().FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null) dbContext.BooksCatalog().Remove(deletedBook);
        }

        public void EditBook(BooksCatalog.Book book)
        {
            var editedBook = dbContext.BooksCatalog().FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                editedBook.Title = book.Title;
                editedBook.BookType = book.BookType;
            }
        }

        public void AddBook(BooksCatalog.Book book)
        {
            var addedBook = new BooksCatalog.Book
            {
                Id = book.Id,
                Title = book.Title,
                BookType = book.BookType
            };

            dbContext.BooksCatalog().Add(addedBook);
        }
    }
}