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
            booksState.BooksCatalog = new BooksCatalog
            {
                Books = new List<Book>
                {
                    new Book { Id = 1, Title = "aaaa", BookType = BookEnum.Adventure },
                    new Book { Id = 2, Title = "bbbb", BookType = BookEnum.Roman },
                    new Book { Id = 3, Title = "cccc", BookType = BookEnum.Document },
                    new Book { Id = 4, Title = "dddd", BookType = BookEnum.Historic },
                    new Book { Id = 5, Title = "eeee", BookType = BookEnum.SciFi },
                    new Book { Id = 6, Title = "ffff", BookType = BookEnum.Document }
                }
            };

            booksState.AvailableBooks = new Dictionary<int, int>
            {
                { booksState.BooksCatalog.Books[0].Id, 32 },
                { booksState.BooksCatalog.Books[1].Id, 2 },
                { booksState.BooksCatalog.Books[2].Id, 18 },
                { booksState.BooksCatalog.Books[3].Id, 6 },
                { booksState.BooksCatalog.Books[4].Id, 2 },
                { booksState.BooksCatalog.Books[5].Id, 40 }
            };
        }

        public List<Book> GetAllAvailableBooks()
        {
            return booksState.BooksCatalog.Books;
        }

        public int GetAmountOfAvailableBooksById(int id)
        {
            Book book = booksState.BooksCatalog.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (book != null && booksState.AvailableBooks.ContainsKey(book.Id))
            {
                int amount = booksState.AvailableBooks[book.Id];

                return amount > 0 ? amount : default;
            }

            return default;
        }

        public int UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            Book updatedBook = booksState.BooksCatalog.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            if (booksState.AvailableBooks.ContainsKey(updatedBook.Id))
            {
                booksState.AvailableBooks[updatedBook.Id] = actualBooksAmount;
            }

            return actualBooksAmount;
        }
    }
}
