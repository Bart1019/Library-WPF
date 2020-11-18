using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Tests.Data.UnitTests.DataGenerators
{
    public class DataGenerator: IDataGenerator
    {
        public DataContext GenerateData()
        {
            DataContext dataContext = new DataContext();

            User user1 = new User {Id = 1, Name = "aaa", Surname = "aaa", AmountOfBooksRented = 1};
            User user2 = new User {Id = 2, Name = "bbb", Surname = "bbb", AmountOfBooksRented = 4};
            User user3 = new User {Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 3};
            User user4 = new User {Id = 4, Name = "ddd", Surname = "ddd", AmountOfBooksRented = 1};
            User user5 = new User {Id = 5, Name = "eee", Surname = "eee", AmountOfBooksRented = 4};
            User user6 = new User {Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6};

            dataContext.Users.Add(user1);
            dataContext.Users.Add(user2);
            dataContext.Users.Add(user3);
            dataContext.Users.Add(user4);
            dataContext.Users.Add(user5);
            dataContext.Users.Add(user6);

            Book book1 = new Book { Id = 1, Title = "aaaa", BookGenre = BookEnum.Adventure };
            Book book2 = new Book { Id = 2, Title = "bbbb", BookGenre = BookEnum.Roman };
            Book book3 = new Book { Id = 3, Title = "cccc", BookGenre = BookEnum.Document };
            Book book4 = new Book { Id = 4, Title = "dddd", BookGenre = BookEnum.Historic };
            Book book5 = new Book { Id = 5, Title = "eeee", BookGenre = BookEnum.SciFi };
            Book book6 = new Book { Id = 6, Title = "ffff", BookGenre = BookEnum.Document };

            dataContext.BookCatalog.Books.Add(book1);
            dataContext.BookCatalog.Books.Add(book2);
            dataContext.BookCatalog.Books.Add(book3);
            dataContext.BookCatalog.Books.Add(book4);
            dataContext.BookCatalog.Books.Add(book5);
            dataContext.BookCatalog.Books.Add(book6);


            BookState bookState = new BookState
            {
                AllBooks = dataContext.BookCatalog,
                AvailableBooksAmount = new Dictionary<Book, int>
                {
                    {book1, 32},
                    {book2, 2},
                    {book3, 18},
                    {book4, 6},
                    {book5, 2},
                    {book6, 40},
                }
            };

            dataContext.BookState = bookState;

            RentalEvent rentalEvent1 = new RentalEvent { RentalDate = default, RentalUser = user1, BookInLibrary = bookState };
            RentalEvent rentalEvent2 = new RentalEvent { RentalDate = default, RentalUser = user2, BookInLibrary = bookState };
            RentalEvent rentalEvent3 = new RentalEvent { RentalDate = default, RentalUser = user3, BookInLibrary = bookState };
            ReturnEvent returnEvent1 = new ReturnEvent { ReturnDate = default, RentalUser = user2 };
            ReturnEvent returnEvent2 = new ReturnEvent { ReturnDate = default, RentalUser = user3 };

            dataContext.BookEvents.Add(rentalEvent1);
            dataContext.BookEvents.Add(rentalEvent2);
            dataContext.BookEvents.Add(rentalEvent3);
            dataContext.BookEvents.Add(returnEvent1);
            dataContext.BookEvents.Add(returnEvent2);

            return dataContext;
        }
    }
}
