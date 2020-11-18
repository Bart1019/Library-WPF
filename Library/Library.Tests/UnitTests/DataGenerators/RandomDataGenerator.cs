using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Tests.Data.UnitTests.DataGenerators
{
    public class RandomDataGenerator: IDataGenerator
    {
        private readonly Random random = new Random();
        private DataContext dataContext = new DataContext();

        public DataContext GenerateData()
        {
            User randomUser = CreateRandomUser();

            dataContext.Users.Add(randomUser);

            Book randomBook = CreateRandomBook();

            dataContext.BookCatalog.Books.Add(randomBook);

            RentalEvent randomRentalEvent = CreateRandomRentalEvent();
            ReturnEvent randomReturnEvent = CreateRandomReturnEvent();

            dataContext.BookEvents.Add(randomRentalEvent);
            dataContext.BookEvents.Add(randomReturnEvent);

            BookState randomBookState = CreateRandomBookState();

            dataContext.BookState = randomBookState;

            return dataContext;
        }

        public User CreateRandomUser()
        {
            User user = new User
            {
                Id = RandomNumber(1,20),
                Name = RandomString(6),
                Surname = RandomString(10),
                AmountOfBooksRented = RandomNumber(0,15)
            };

            return user;
        }

        public Book CreateRandomBook()
        {
            Book book = new Book
            {
                Id = RandomNumber(1,100),
                Author = RandomString(20),
                BookGenre = RandomGenre(),
                Title = RandomString(10)
            };

            return book;
        }

        public BookState CreateRandomBookState()
        {
            BookState bookState = new BookState
            {
                AllBooks = dataContext.BookCatalog,
                AvailableBooksAmount = new Dictionary<Book, int>
                {
                    {CreateRandomBook(), RandomNumber(1,10) },
                    {CreateRandomBook(), RandomNumber(1,10) },
                    {CreateRandomBook(), RandomNumber(1,10) },
                    {CreateRandomBook(), RandomNumber(1,10) },
                    {CreateRandomBook(), RandomNumber(1,10) },
                    {CreateRandomBook(), RandomNumber(1,10) },

                }
            };

            return bookState;
        }

        public RentalEvent CreateRandomRentalEvent()
        {
            RentalEvent rentalEvent = new RentalEvent
            {
                BookInLibrary = CreateRandomBookState(),
                RentalDate = default,
                RentalUser = CreateRandomUser()
            };

            return rentalEvent;
        }

        public ReturnEvent CreateRandomReturnEvent()
        {
           ReturnEvent returnEvent = new ReturnEvent
           {
               RentalUser = CreateRandomUser(),
               ReturnDate = default
           };

           return returnEvent;
        }

        public int RandomNumber(int bottomBorder, int upperBorder)
        {
            return random.Next(bottomBorder, upperBorder);
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public BookEnum RandomGenre()
        {
            Array values = Enum.GetValues(typeof(BookEnum));
            BookEnum randomGenre = (BookEnum)values.GetValue(random.Next(values.Length));
            return randomGenre;
        }
    }
}
