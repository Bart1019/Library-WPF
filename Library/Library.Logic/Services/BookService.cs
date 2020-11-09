using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Logic.Services
{
    public class BookService
    {
        private readonly IBooksCatalogRepository booksCatalogRepository;

        public BookService(IBooksCatalogRepository booksCatalogRepository)
        {
            this.booksCatalogRepository = booksCatalogRepository;
        }

        public List<Book> GetAllBooks()
        {
            List <Book> books = booksCatalogRepository.GetAllBooks();

            return books.Count == 0 ? null : books;
        }

        public Book GetBook(int id)
        {
            Book bookById = booksCatalogRepository.GetBookById(id);

            if (bookById.Equals(null))
            {
                return null;
            }

            return bookById;
        }

        public Book GetBook(BookEnum bookType)
        {
            Book bookByType = booksCatalogRepository.GetBookByType(bookType);

            if (bookByType.Equals(null))
            {
                return null;
            }

            return bookByType;
        }

        public void DeleteBook(int id)
        {
            booksCatalogRepository.DeleteBook(id);
        }

        public void EditBook(Book book)
        {
            booksCatalogRepository.EditBook(book);
        }

        public void AddBook(Book book)
        {
            booksCatalogRepository.AddBook(book);
        }
    }
}
