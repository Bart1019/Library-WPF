using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBooksCatalogRepository
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        void EditBook(Book book);
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByType(BookEnum bookType);
    }
}