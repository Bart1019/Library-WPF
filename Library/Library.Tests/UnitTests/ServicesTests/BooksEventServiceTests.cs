using System;
using System.Collections.Generic;
using Library.Data;
using Library.Logic;
using Moq;
using Xunit;

namespace Library.LogicTests
{
    public class BooksEventServiceTests
    {
        public BooksEventServiceTests()
        {
            bookEventRepositoryMock = new Mock<IBookEventRepository>();
            bookStateRepositoryMock = new Mock<IBooksStateRepository>();
            userRepositoryMock = new Mock<IUserRepository>();
            booksCatalogRepositoryMock = new Mock<IBooksCatalogRepository>();

            bookEventService = new BookEventService(bookEventRepositoryMock.Object, bookStateRepositoryMock.Object,
                userRepositoryMock.Object, booksCatalogRepositoryMock.Object);

            bookRentalEvents = new List<BookEvent>
            {
                new RentalEvent {EventDate = default, RentalUser = default, BookInLibrary = default},
                new RentalEvent {EventDate = default, RentalUser = default, BookInLibrary = default},
                new RentalEvent {EventDate = default, RentalUser = default}
            };

            bookReturnEvents = new List<BookEvent>
            {
                new ReturnEvent {EventDate = default, RentalUser = default, BookInLibrary = default},
                new ReturnEvent {EventDate = default, RentalUser = default, BookInLibrary = default},
                new ReturnEvent {EventDate = default, RentalUser = default}
            };

            _bookState.AllBooks = new BookCatalog
            {
                Books = new List<Book>
                {
                    new Book {Id = 1, Title = "aaaa", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                    new Book {Id = 2, Title = "bbbb", BookGenre = BookEnum.Roman, Author = "Bbbb"},
                    new Book {Id = 3, Title = "cccc", BookGenre = BookEnum.Document, Author = "Cccc"},
                    new Book {Id = 4, Title = "dddd", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                    new Book {Id = 5, Title = "eeee", BookGenre = BookEnum.Roman, Author = "Bbbb"},
                    new Book {Id = 6, Title = "ffff", BookGenre = BookEnum.Document, Author = "Cccc"}
                }
            };

            availableAmountOfParticularBook = random.Next();

            bookStateRepositoryMock.Setup(x => x.GetAmountOfAvailableBooksById(It.IsAny<int>()))
                .Returns(availableAmountOfParticularBook);
            bookStateRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(_bookState.AllBooks.Books);
        }

        private readonly Mock<IBookEventRepository> bookEventRepositoryMock;
        private readonly Mock<IBooksStateRepository> bookStateRepositoryMock;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly Mock<IBooksCatalogRepository> booksCatalogRepositoryMock;
        private readonly BookEventService bookEventService;
        private readonly List<BookEvent> bookRentalEvents;
        private readonly List<BookEvent> bookReturnEvents;
        private readonly BookState _bookState = new BookState();
        private readonly Random random = new Random();
        private int availableAmountOfParticularBook;

        [Fact]
        public void ShouldGetAllRentalsEvents()
        {
            //Arrange
            bookEventRepositoryMock.Setup(x => x.GetAllBookRentalEvents()).Returns(bookRentalEvents);

            //Act
            var resultedBookEvents = bookEventService.GetAllRentals();

            //Assert
            Assert.Equal(resultedBookEvents, bookRentalEvents);
        }

        [Fact]
        public void ShouldGetAllReturnEvents()
        {
            //Arrange
            bookEventRepositoryMock.Setup(x => x.GetAllBookReturnEvents()).Returns(bookReturnEvents);

            //Act
            var resultedBookEvents = bookEventService.GetAllReturns();

            //Assert
            Assert.Equal(resultedBookEvents, bookReturnEvents);
        }
    }
}