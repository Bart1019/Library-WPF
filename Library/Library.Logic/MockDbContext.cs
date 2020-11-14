using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Logic
{
    public class MockDbContext: IMockDbContext
    {
        private List<BookEvent> bookEvents;
        private BooksState booksState = new BooksState();
        private BooksCatalog bookCatalog = new BooksCatalog();
        private List<User> users;

        public List<BookEvent> BookEvents()
        {
            bookEvents = new List<BookEvent>
            {
                new RentalEvent { RentalDate = default, RentalUser = default, BooksInLibrary = default },
                new RentalEvent { RentalDate = default, RentalUser = default, BooksInLibrary = default },
                new ReturnEvent { ReturnDate = default, RentalUser = default },
            };

            return bookEvents;
        }

        public List<Book> BooksCatalog()
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

            return booksState.BooksCatalog.Books;
        }

        public Dictionary<int, int> AvailableBooks()
        {
            booksState.AvailableBooks = new Dictionary<int, int>
            {
                { booksState.BooksCatalog.Books[0].Id, 32 },
                { booksState.BooksCatalog.Books[1].Id, 2 },
                { booksState.BooksCatalog.Books[2].Id, 18 },
                { booksState.BooksCatalog.Books[3].Id, 6 },
                { booksState.BooksCatalog.Books[4].Id, 2 },
                { booksState.BooksCatalog.Books[5].Id, 40 }
            };

            return booksState.AvailableBooks;
        }

        public List<Book> Books()
        {
            bookCatalog.Books = new List<Book>
            {
                new Book { Id = 1, Title = "aaaa", BookType = BookEnum.Adventure },
                new Book { Id = 2, Title = "bbbb", BookType = BookEnum.Roman },
                new Book { Id = 3, Title = "cccc", BookType = BookEnum.Document },
                new Book { Id = 4, Title = "dddd", BookType = BookEnum.Adventure },
                new Book { Id = 5, Title = "eeee", BookType = BookEnum.Roman },
                new Book { Id = 6, Title = "ffff", BookType = BookEnum.Document }
            };

            return bookCatalog.Books;
        }

        public List<User> Users()
        {
            users = new List<User>
            {
                new User {Id = 1, Name = "aaa", Surname = "aaaa", AmountOfBooksRented = 1},
                new User {Id = 2, Name = "bbb", Surname = "bbb", AmountOfBooksRented = 4},
                new User {Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 3},
                new User {Id = 4, Name = "ddd", Surname = "ddd", AmountOfBooksRented = 1},
                new User {Id = 5, Name = "eee", Surname = "eee", AmountOfBooksRented = 4},
                new User {Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6},
            };

            return users;
        }
    }
}
