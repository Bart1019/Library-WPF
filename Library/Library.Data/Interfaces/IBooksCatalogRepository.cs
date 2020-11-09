using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Data.Interfaces
{
    public interface IBooksCatalogRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByType(BookEnum bookType);
        void DeleteBook(int id);
        void EditBook(Book book);
        void AddBook(Book book);
    }
}
