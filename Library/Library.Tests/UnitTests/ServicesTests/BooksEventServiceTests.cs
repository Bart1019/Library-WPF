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
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Tests.UnitTests.ServicesTests
{
    public class BooksEventServiceTests
    {
        private readonly Mock<IBookEventRepository> bookEventRepositoryMock;
        private readonly Mock<IBooksStateRepository> bookStateRepositoryMock;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly BookEventService bookEventService;
        private readonly List<BookEvent> bookEvents;
        private User user;
        private BooksState booksState = new BooksState();
        private Random random = new Random();
        private int availableAmountOfParticularBook;

        public BooksEventServiceTests()
        {
            bookEventRepositoryMock = new Mock<IBookEventRepository>();
            bookStateRepositoryMock = new Mock<IBooksStateRepository>();
            userRepositoryMock = new Mock<IUserRepository>();
            bookEventService = new BookEventService(bookEventRepositoryMock.Object, bookStateRepositoryMock.Object, userRepositoryMock.Object);
            
            bookEvents = new List<BookEvent>
            {
                new RentalEvent { RentalDate = default, RentalUser = default, BooksInLibrary = default },
                new RentalEvent { RentalDate = default, RentalUser = default, BooksInLibrary = default },
                new ReturnEvent { ReturnDate = default, RentalUser = default },
            };
            booksState.BooksCatalog = new BooksCatalog
            {
                Books = new List<Book>
                {
                    new Book { Id = 1, Title = "aaaa", BookType = BookEnum.Adventure },
                    new Book { Id = 2, Title = "bbbb", BookType = BookEnum.Roman },
                    new Book { Id = 3, Title = "cccc", BookType = BookEnum.Document },
                    new Book { Id = 4, Title = "dddd", BookType = BookEnum.Adventure },
                    new Book { Id = 5, Title = "eeee", BookType = BookEnum.Roman },
                    new Book { Id = 6, Title = "ffff", BookType = BookEnum.Document }
                }
            };

            user = new User
            {
                Id = 1,
                Name = "naaa",
                Surname = "saaa",
                AmountOfBooksRented = 0
            };
        }

        [Fact]
        public void ShouldGetAllBookEvents()
        {
            //Arrange
            bookEventRepositoryMock.Setup(x => x.GetAllBookEvents()).Returns(bookEvents);

            //Act
            var resultedBookEvents = bookEventService.GetAllBookEvents();

            //Assert
            Assert.Equal(resultedBookEvents, bookEvents);
        }

        [Fact]
        public void ShouldCreateNewRental()
        {
            //Arrange
            DateTime rentDate = new DateTime(2020, 11, 13);
            availableAmountOfParticularBook = random.Next();
            int expectedAmountOfAvailableBooks = availableAmountOfParticularBook - 1;
            RentalEvent expectedRentalEvent = new RentalEvent
            {
                RentalUser = user,
                BooksInLibrary = booksState,
                RentalDate = rentDate
            };
            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);
            bookStateRepositoryMock.Setup(x => x.GetAmountOfAvailableBooksById(It.IsAny<int>()))
                .Returns(availableAmountOfParticularBook);
            bookStateRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(booksState.BooksCatalog.Books);
            bookStateRepositoryMock.Setup(x => x.UpdateBooksAmount(It.IsAny<int>(), It.IsAny<int>())).Returns(--availableAmountOfParticularBook);
            
            //Act
            var resultedRentalEvent = bookEventService.RentBook(user.Id, booksState.BooksCatalog.Books[0].Id, rentDate);

            //Assert
            Assert.Equal(1, user.AmountOfBooksRented);
            Assert.Equal(expectedAmountOfAvailableBooks, availableAmountOfParticularBook);
            Assert.Equal(expectedRentalEvent.ToString(),resultedRentalEvent.ToString());
        }

        [Fact]
        public void ShouldSuccessfullyGiveBookBack()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
