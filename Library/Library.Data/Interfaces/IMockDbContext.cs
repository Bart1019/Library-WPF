using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IMockDbContext
    {
        Dictionary<int, int> AvailableBooks();
        List<BookEvent> BookEvents();
        List<BooksCatalog.Book> Books();
        List<BooksCatalog.Book> BooksCatalog();
        List<User> Users();
    }
}