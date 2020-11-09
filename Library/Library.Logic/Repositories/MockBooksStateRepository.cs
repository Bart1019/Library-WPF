using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Logic.Repositories
{
    public class MockBooksStateRepository : IBooksStateRepository
    {
        private BooksState booksState = new BooksState();

        public MockBooksStateRepository()
        {
            booksState.BooksCatalog.Books = new List<Book>
            {
                new Book { Id = 1, Title = "aaaa", BookType = BookEnum.Adventure },
                new Book { Id = 2, Title = "bbbb", BookType = BookEnum.Roman },
                new Book { Id = 3, Title = "cccc", BookType = BookEnum.Document },
                new Book { Id = 4, Title = "dddd", BookType = BookEnum.Historic },
                new Book { Id = 5, Title = "eeee", BookType = BookEnum.SciFi },
                new Book { Id = 6, Title = "ffff", BookType = BookEnum.Document }
            };

            booksState.AvailableBooks = new Dictionary<int, int>
            {
                {1, 32 },
                {2, 2 },
                {3, 18 },
                {4, 6 },
                {5, 2 },
                {6, 40 }
            };
        }

        public List<Book> GetAllAvailableBooks()
        {
            return booksState.BooksCatalog.Books;
        }

        public void UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            Dictionary<int, int> updateDictionary = booksState.AvailableBooks;

            if (updateDictionary.ContainsKey(bookId))
            {
                updateDictionary[bookId] = actualBooksAmount;
            }
        }
    }
}
