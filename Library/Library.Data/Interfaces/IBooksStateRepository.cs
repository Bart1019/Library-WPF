using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBooksStateRepository
    {
        List<BooksCatalog.Book> GetAllAvailableBooks();
        int GetAmountOfAvailableBooksById(int id);
        int UpdateBooksAmount(int bookId, int actualBooksAmount);
    }
}