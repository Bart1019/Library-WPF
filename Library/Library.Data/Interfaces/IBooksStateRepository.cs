using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Data.Interfaces
{
    public interface IBooksStateRepository
    {
        List<Book> GetAllAvailableBooks();
        void UpdateBooksAmount(int bookId, int actualBookAmount);
    }
}
