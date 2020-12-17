using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;

namespace Library.Logic
{
    public interface IBookCatalogService
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        void EditBook(Book book);
        List<Book> GetAllBooks();
        Book GetBook(int id);
        Book GetBook(BookEnum bookType);
    }
}
