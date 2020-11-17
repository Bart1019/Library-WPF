using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBooksCatalogRepository
    {
        void AddBook(BookCatalog.Book book);
        void DeleteBook(int id);
        void EditBook(BookCatalog.Book book);
        List<BookCatalog.Book> GetAllBooks();
        BookCatalog.Book GetBookById(int id);
        BookCatalog.Book GetBookByType(BookEnum bookType);
    }
}