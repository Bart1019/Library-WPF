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
    public class BooksStateServiceTests
    {
        private readonly Mock<IBooksStateRepository> libraryRepositoryMock;
        private readonly BooksStateService booksStateService;
        private BooksState booksState = new BooksState();

        public BooksStateServiceTests()
        {
            libraryRepositoryMock = new Mock<IBooksStateRepository>();
            booksStateService = new BooksStateService(libraryRepositoryMock.Object);
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
        }

        [Fact]
        public void ShouldReturnAllAvailableOrAllUnavailableBooksBasedOnCondition()
        {
            //Arrange
            libraryRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(booksState.BooksCatalog.Books);

            //Act
            var returnedBooks = booksStateService.GetAllAvailableBooks();

            //Assert
            Assert.Equal(booksState.BooksCatalog.Books, returnedBooks);
        }

        [Fact]
        public void ShouldUpdateBookWithProperlyChangedState()
        {
            //Arrange
            libraryRepositoryMock.Setup(x => x.UpdateBooksAmount(It.IsAny<int>(), It.IsAny<int>()));

            //Act
            booksStateService.UpdateBooksAmount(default, default);

            //Assert
        }
    }
}
