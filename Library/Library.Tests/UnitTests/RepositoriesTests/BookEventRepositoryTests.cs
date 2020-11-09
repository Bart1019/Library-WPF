using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class BookEventRepositoryTests
    {
        private readonly MockBookEventRepository bookEventRepository;

        public BookEventRepositoryTests()
        {
            bookEventRepository = new MockBookEventRepository();
        }

        [Fact]
        public void ShouldReturnAllRentals()
        {
            //Arrange

            //Act
            var returnedRentals = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(returnedRentals.Count.Equals(3));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ShouldReturnRentalId(int id)
        {
            //Arrange
            List<BookEvent> expectedRentals = new List<BookEvent>
            {
                new BookEvent { Id = 1, RentalDate = default, GiveBackDate = default, EventType = default, RentalUser = default, BooksInLibrary = default },
                new BookEvent { Id = 2, RentalDate = default, GiveBackDate = default, EventType = default, RentalUser = default, BooksInLibrary = default },
                new BookEvent { Id = 3, RentalDate = default, GiveBackDate = default, EventType = default, RentalUser = default, BooksInLibrary = default }
            };

            //Act
            var returnedRental = bookEventRepository.GetBookEventById(id);

            //Assert
            switch (id)
            {
                case 1:
                    Assert.Equal(expectedRentals[0].Id, returnedRental.Id);
                    break;
                case 2:
                    Assert.Equal(expectedRentals[1].Id, returnedRental.Id);
                    break;
                case 3:
                    Assert.Equal(expectedRentals[2].Id, returnedRental.Id);
                    break;
            }
        }

        [Fact]
        public void ShouldDeleteRental()
        {
            //Arrange

            //Act
            bookEventRepository.DeleteBookEvent(1);

            var rentals = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(rentals.Count.Equals(2));
        }

        [Fact]
        public void ShouldEditRental()
        {
            //Arrange
            BookEvent expectedBookEvent = new BookEvent
            {
                Id = 1,
                RentalDate = new DateTime(2020,11,03),
                GiveBackDate = new DateTime(2020, 11, 04)
            };

            //Act
            bookEventRepository.EditBookEvent(expectedBookEvent);

            var rental = bookEventRepository.GetBookEventById(expectedBookEvent.Id);

            //Assert
            Assert.Equal(expectedBookEvent.Id, rental.Id);
            Assert.Equal(expectedBookEvent.RentalDate, rental.RentalDate);
            Assert.Equal(expectedBookEvent.GiveBackDate, rental.GiveBackDate);
        }

        [Fact]
        public void ShouldAddRental()
        {
            //Arrange
            BookEvent newBookEvent = new BookEvent
            {
                Id = 4,
                RentalDate = new DateTime(2020, 11, 03),
                GiveBackDate = new DateTime(2020, 11, 04)
            };

            //Act
            bookEventRepository.AddBookEvent(newBookEvent);

            var books = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(books.Count.Equals(4));
        }
    }
}
