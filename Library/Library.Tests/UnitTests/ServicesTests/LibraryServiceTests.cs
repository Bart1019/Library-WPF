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
    public class LibraryServiceTests
    {
        private readonly Mock<ILibraryRepository> libraryRepositoryMock;
        private readonly LibraryService libraryService;
        private readonly List<Book> availableBooks;
        private readonly List<Book> unAvailableBooks;

        public LibraryServiceTests()
        {
            libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryService = new LibraryService(libraryRepositoryMock.Object);
            unAvailableBooks = new List<Book>
            {
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, IsAvailable = false},
                new Book {Id = 4, Title = "dddd", BookType = BookEnum.Historic, IsAvailable = false},
                new Book {Id = 5, Title = "eeee", BookType = BookEnum.SciFi, IsAvailable = false},
            };
            availableBooks = new List<Book>
            {
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, IsAvailable = true},
                new Book {Id = 4, Title = "dddd", BookType = BookEnum.Historic, IsAvailable = true},
                new Book {Id = 5, Title = "eeee", BookType = BookEnum.SciFi, IsAvailable = true},
            };
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldReturnAllAvailableOrAllUnavailableBooksBasedOnCondition(bool isAvailable)
        {
            //Arrange
            libraryRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(availableBooks);
            libraryRepositoryMock.Setup(x => x.GetAllUnavailableBooks()).Returns(unAvailableBooks);

            //Act
            switch (isAvailable)
            {
                case true:
                    //Act
                    var returnedBooks = libraryService.GetAllAvailableBooks();

                    //Assert
                    Assert.Equal(availableBooks,returnedBooks);

                    break;

                case false:
                    //Act
                    returnedBooks = libraryService.GetAllUnavailableBooks();

                    //Assert
                    Assert.Equal(unAvailableBooks, returnedBooks);

                    break;
            }
        }

        [Fact]
        public void ShouldUpdateBookWithProperlyChangedState()
        {
            //Arrange
            libraryRepositoryMock.Setup(x => x.UpdateBookState(It.IsAny<Book>(), It.IsAny<bool>()));

            //Act
            libraryService.UpdateBookState(default, default);

            //Assert
        }
    }
}
