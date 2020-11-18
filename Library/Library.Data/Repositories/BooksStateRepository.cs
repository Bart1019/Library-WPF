using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Data.Repositories
{
    public class BooksStateRepository : IBooksStateRepository
    {
        private readonly DbContext dbContext;

        public BooksStateRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Book> GetAllAvailableBooks()
        {
            return dbContext.BookState.AllBooks.Books;
        }

        public int GetAmountOfAvailableBooksById(int id)
        {
            var book = dbContext.BookState.AllBooks.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (book != null && dbContext.BookState.AvailableBooksAmount.ContainsKey(book))
            {
                var amount = dbContext.BookState.AvailableBooksAmount[book];

                return amount > 0 ? amount : default;
            }

            return default;
        }

        public int UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            var updatedBook = dbContext.BookState.AllBooks.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            if (updatedBook != null && dbContext.BookState.AvailableBooksAmount.ContainsKey(updatedBook))
            {
                dbContext.BookState.AvailableBooksAmount[updatedBook] = actualBooksAmount;
            }

            return actualBooksAmount;
        }
    }
}