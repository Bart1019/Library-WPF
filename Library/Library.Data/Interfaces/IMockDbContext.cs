using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Data.Interfaces
{
    public interface IMockDbContext
    {
        List<BookEvent> BookEvents();
        List<Book> BooksCatalog();
        Dictionary<int, int> AvailableBooks();
        List<Book> Books();
        List<User> Users();
    }
}
