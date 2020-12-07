using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public interface IBooksStateRepository
    {
        IQueryable<Book> GetAllAvailableBooks();
        int GetAmountOfAvailableBooksById(int id);
        int UpdateBooksAmount(int bookId, int actualBooksAmount);
    }
}