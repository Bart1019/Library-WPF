using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Logic.Services
{
    public class BooksStateService
    {
        private readonly IBooksStateRepository booksStateRepository;

        public BooksStateService(IBooksStateRepository booksStateRepository)
        {
            this.booksStateRepository = booksStateRepository;
        }

        public List<Book> GetAllAvailableBooks()
        {
            List<Book> availableBooks = booksStateRepository.GetAllAvailableBooks();

            return availableBooks.Count == 0 ? null : availableBooks;
        }

        public int GetAmountOfAvailableBooks(int id)
        {
            int amount = booksStateRepository.GetAmountOfAvailableBooksById(id);
            return amount;
        }

        public void UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            booksStateRepository.UpdateBooksAmount(bookId, actualBooksAmount);
        }
    }
}
