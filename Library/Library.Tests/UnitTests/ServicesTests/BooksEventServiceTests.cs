using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Logic.Services;
using Moq;
using Xunit;

namespace Library.Tests.UnitTests.ServicesTests
{
    public class BooksEventServiceTests
    {
       /*private readonly Mock<IBookEventRepository> rentalRepositoryMock;
        private readonly Mock<IBooksStateRepository> libraryRepositoryMock;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private BookEventService bookEventService;
        private readonly List<RentalEvent> rentals = new List<RentalEvent>();
        private readonly RentalEvent _bookEvent = new RentalEvent();
        private readonly List<BooksCatalog> availableBooks;
        private readonly List<BooksCatalog> unAvailableBooks;
        private User user;
        private BooksCatalog _rentedBooksCatalog;

        public BooksEventServiceTests()
        {
            rentalRepositoryMock = new Mock<IBookEventRepository>();
            libraryRepositoryMock = new Mock<IBooksStateRepository>();
            userRepositoryMock = new Mock<IUserRepository>();
            bookEventService = new BookEventService(rentalRepositoryMock.Object, libraryRepositoryMock.Object, userRepositoryMock.Object);
            rentals = new List<RentalEvent>
            {
                new RentalEvent { Id = 1, EventDate = default, GiveBackDate = default, RentalUser = default, BooksInLibrary = default },
                new RentalEvent { Id = 2, EventDate = default, GiveBackDate = default, RentalUser = default, BooksInLibrary = default },
                new RentalEvent { Id = 3, EventDate = default, GiveBackDate = default, RentalUser = default, BooksInLibrary = default }
            };
            unAvailableBooks = new List<BooksCatalog>
            {
                new BooksCatalog {Id = 4, Title = "dddd", BookType = BookEnum.Document, IsAvailable = false},
                new BooksCatalog {Id = 5, Title = "eeee", BookType = BookEnum.Historic, IsAvailable = false},
                new BooksCatalog {Id = 6, Title = "ffff", BookType = BookEnum.SciFi, IsAvailable = false},
            };
            availableBooks = new List<BooksCatalog>
            {
                new BooksCatalog {Id = 1, Title = "aaaa", BookType = BookEnum.Document, IsAvailable = true},
                new BooksCatalog {Id = 2, Title = "bbbb", BookType = BookEnum.Historic, IsAvailable = true},
                new BooksCatalog {Id = 3, Title = "cccc", BookType = BookEnum.SciFi, IsAvailable = true},
            };
            user = new User
            {
                  Id = 1, 
                  Name = "aaa", 
                  Surname = "aaaa", 
                  AmountOfBooksRented = 1
             };
            _bookEvent = new RentalEvent
            {
                Id = 4,
            };
        }

        [Fact]
        public void ShouldGetAllRentals()
        {
            //Arrange
            rentalRepositoryMock.Setup(x => x.GetAllBookEvents()).Returns(rentals);

            //Act
            var resultedRentals = bookEventService.GetAllBookEvents();

            //Assert
            Assert.Equal(resultedRentals, rentals);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(default)]
        public void ShouldGetRentalById(int id)
        {
            //Arrange
            rentalRepositoryMock.Setup(x => x.GetBookEventById(It.IsAny<int>())).Returns(_bookEvent);

            //Act
            var resultedRental = bookEventService.GetRental(id);

            //Assert
            Assert.Equal(resultedRental, _bookEvent);
        }

        [Fact]
        public void ShouldDeleteRental()
        {
            //Arrange
            rentalRepositoryMock.Setup(x => x.DeleteBookEvent(It.IsAny<int>()));

            //Act
            bookEventService.DeleteRental(default);

            //Assert
        }

        [Fact]
        public void ShouldEditExistingRental()
        {
            //Arrange
            rentalRepositoryMock.Setup(x => x.EditBookEvent(It.IsAny<RentalEvent>()));

            //Act
            bookEventService.EditExistingRental(default);

            //Assert
        }

        [Theory]
       // [InlineData(1)]
        //[InlineData(2)]
        [InlineData(3)]
       // [InlineData(default)]
        public void ShouldCreateNewRental(int bookId)
        {
            //Arrange
            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);
            libraryRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(availableBooks);
            _rentedBooksCatalog = availableBooks.FirstOrDefault(i => i.Id.Equals(bookId));
            DateTime rentalDate = new DateTime(2020, 11, 02);

            //Act
            var resultedRental = bookEventService.CreateNewRental(_bookEvent.Id, user.Id, _rentedBooksCatalog.Id, rentalDate);

            //Assert
            Assert.True(user.AmountOfBooksRented.Equals(2));
            Assert.True(_rentedBooksCatalog.IsAvailable.Equals(false));
            Assert.Equal(_bookEvent.Id, resultedRental.Id);
        }

        [Fact]
        public void ShouldSuccessfullyGiveBookBack()
        {
            //Arrange

            //Act

            //Assert
        }*/
    }
}
