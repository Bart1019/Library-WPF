using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Services
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
           return bookRepository.GetAllBooks().ToList();
        }

        public Book GetBook(int id)
        {
            return bookRepository.GetBookById(id);
        }

        public Book GetBook(BookEnum bookType)
        {
            return bookRepository.GetBookByType(bookType);
        }

        public void DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
        }

        public void EditBook(Book book)
        {
            bookRepository.EditBook(book);
        }

        public void AddBook(Book book)
        {
            bookRepository.AddBook(book);
        }
    }
}
