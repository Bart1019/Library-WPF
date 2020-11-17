using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class BooksCatalogRepository : IBooksCatalogRepository
    {
        private readonly DbContext dbContext;

        public BooksCatalogRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BookCatalog.Book> GetAllBooks()
        {
            return dbContext.BookCatalog.Books;
        }

        public BookCatalog.Book GetBookById(int id)
        {
            return dbContext.BookCatalog.Books.FirstOrDefault(i => i.Id.Equals(id));
        }

        public BookCatalog.Book GetBookByType(BookEnum bookType)
        {
            return dbContext.BookCatalog.Books.FirstOrDefault(t => t.BookType.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            var deletedBook = dbContext.BookCatalog.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null) dbContext.BookCatalog.Books.Remove(deletedBook);
        }

        public void EditBook(BookCatalog.Book book)
        {
            var editedBook = dbContext.BookCatalog.Books.FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                editedBook.Title = book.Title;
                editedBook.BookType = book.BookType;
            }
        }

        public void AddBook(BookCatalog.Book book)
        {
            var addedBook = new BookCatalog.Book
            {
                Id = book.Id,
                Title = book.Title,
                BookType = book.BookType
            };

            dbContext.BookCatalog.Books.Add(addedBook);
        }
    }
}