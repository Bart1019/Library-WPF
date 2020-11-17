using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic
{
    public class DbContext
    {
        public List<User> Users = new List<User>();
        public List<BookEvent> BookEvents = new List<BookEvent>();
        public BookState BookState = new BookState();
        public BookCatalog BookCatalog = new BookCatalog();

        /*public List<BookEvent> BookEvents()
        {
            bookEvents = new List<BookEvent>
            {
                new RentalEvent {RentalDate = default, RentalUser = default, BookInLibrary = default},
                new RentalEvent {RentalDate = default, RentalUser = default, BookInLibrary = default},
                new ReturnEvent {ReturnDate = default, RentalUser = default}
            };

            return bookEvents;
        }

        public BookState AvailableBook()
        {
            _bookState.AvailableBook = new BookCatalog
            {
                Books = new List<BookCatalog.Book>
                {
                    new BookCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                    new BookCatalog.Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman},
                    new BookCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                    new BookCatalog.Book {Id = 4, Title = "dddd", BookType = BookEnum.Historic},
                    new BookCatalog.Book {Id = 5, Title = "eeee", BookType = BookEnum.SciFi},
                    new BookCatalog.Book {Id = 6, Title = "ffff", BookType = BookEnum.Document}
                }
            };

            return _bookState;
        }

        public Dictionary<int, int> AvailableBooksAmount()
        {
            _bookState.AvailableBooksAmount = new Dictionary<int, int>
            {
                {_bookState.AvailableBook.Books[0].Id, 32},
                {_bookState.AvailableBook.Books[1].Id, 2},
                {_bookState.AvailableBook.Books[2].Id, 18},
                {_bookState.AvailableBook.Books[3].Id, 6},
                {_bookState.AvailableBook.Books[4].Id, 2},
                {_bookState.AvailableBook.Books[5].Id, 40}
            };

            return _bookState.AvailableBooksAmount;
        }

        public BookCatalog BookCatalog()
        {
            bookCatalog.Books = new List<BookCatalog.Book>
            {
                new BookCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                new BookCatalog.Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman},
                new BookCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                new BookCatalog.Book {Id = 4, Title = "dddd", BookType = BookEnum.Adventure},
                new BookCatalog.Book {Id = 5, Title = "eeee", BookType = BookEnum.Roman},
                new BookCatalog.Book {Id = 6, Title = "ffff", BookType = BookEnum.Document}
            };

            return bookCatalog;
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
                new User {Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6}
            };

            return users;
        }*/
    }
}