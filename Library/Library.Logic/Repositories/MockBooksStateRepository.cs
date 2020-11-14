using System.Collections.Generic;
using System.Linq;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockBooksStateRepository : IBooksStateRepository
    {
        private readonly MockDbContext dbContext;

        public MockBooksStateRepository(MockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BooksCatalog.Book> GetAllAvailableBooks()
        {
            return dbContext.BooksCatalog();
        }

        public int GetAmountOfAvailableBooksById(int id)
        {
            var book = dbContext.BooksCatalog().FirstOrDefault(i => i.Id.Equals(id));

            if (book != null && dbContext.AvailableBooks().ContainsKey(book.Id))
            {
                var amount = dbContext.AvailableBooks()[book.Id];

                return amount > 0 ? amount : default;
            }

            return default;
        }

        public int UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            var updatedBook = dbContext.BooksCatalog().FirstOrDefault(i => i.Id.Equals(bookId));

            if (dbContext.AvailableBooks().ContainsKey(updatedBook.Id))
                dbContext.AvailableBooks()[updatedBook.Id] = actualBooksAmount;

            return actualBooksAmount;
        }
    }
}