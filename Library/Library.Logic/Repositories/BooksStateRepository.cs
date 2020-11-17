using System.Collections.Generic;
using System.Linq;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class BooksStateRepository : IBooksStateRepository
    {
        private readonly DbContext dbContext;

        public BooksStateRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BookCatalog.Book> GetAllAvailableBooks()
        {
            return dbContext.BookState.AvailableBook.Books;
        }

        public int GetAmountOfAvailableBooksById(int id)
        {
            var book = dbContext.BookState.AvailableBook.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (book != null && dbContext.BookState.AvailableBooksAmount.ContainsKey(book.Id))
            {
                var amount = dbContext.BookState.AvailableBooksAmount[book.Id];

                return amount > 0 ? amount : default;
            }

            return default;
        }

        public int UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            var updatedBook = dbContext.BookState.AvailableBook.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            if (dbContext.BookState.AvailableBooksAmount.ContainsKey(updatedBook.Id))
                dbContext.BookState.AvailableBooksAmount[updatedBook.Id] = actualBooksAmount;

            return actualBooksAmount;
        }
    }
}