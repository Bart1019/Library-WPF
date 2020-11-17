using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Logic.Services;
using Moq;
using Xunit;

namespace Library.Tests.UnitTests.ServicesTests
{
    public class BooksCatalogServiceTests
    {
        public BooksCatalogServiceTests()
        {
            bookRepositoryMock = new Mock<IBooksCatalogRepository>();
            bookService = new BooksCatalogService(bookRepositoryMock.Object);
            _bookCatalog.Books = new List<BookCatalog.Book>
            {
                new BookCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                new BookCatalog.Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman},
                new BookCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                new BookCatalog.Book {Id = 4, Title = "dddd", BookType = BookEnum.Adventure},
                new BookCatalog.Book {Id = 5, Title = "eeee", BookType = BookEnum.Roman},
                new BookCatalog.Book {Id = 6, Title = "ffff", BookType = BookEnum.Document}
            };
        }

        private readonly Mock<IBooksCatalogRepository> bookRepositoryMock;
        private readonly BooksCatalogService bookService;
        private readonly BookCatalog.Book book = new BookCatalog.Book();
        private readonly BookCatalog _bookCatalog = new BookCatalog();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(default)]
        public void ShouldGetBookById(int id)
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Returns(book);

            //Act
            var returnedBook = bookService.GetBook(id);

            //Assert
            Assert.Equal(book, returnedBook);
        }

        [Theory]
        [InlineData(BookEnum.Adventure)]
        [InlineData(BookEnum.Document)]
        [InlineData(BookEnum.Roman)]
        [InlineData(default)]
        public void ShouldReturnBookByBookType(BookEnum bookType)
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.GetBookByType(It.IsAny<BookEnum>())).Returns(book);

            //Act
            var returnedBook = bookService.GetBook(bookType);

            //Assert
            Assert.Equal(book, returnedBook);
        }

        [Fact]
        public void ShouldAddBook()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.AddBook(It.IsAny<BookCatalog.Book>()));

            //Act
            bookService.AddBook(default);

            //Assert
        }

        [Fact]
        public void ShouldDeleteBook()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.DeleteBook(It.IsAny<int>()));

            //Act
            bookService.DeleteBook(default);

            //Assert
        }

        [Fact]
        public void ShouldEditBook()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.EditBook(It.IsAny<BookCatalog.Book>()));


            //Act
            bookService.EditBook(default);

            //Assert
        }

        [Fact]
        public void ShouldGetAllBooks()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.GetAllBooks()).Returns(_bookCatalog.Books);

            //Act
            var resultedBooks = bookService.GetAllBooks();

            //Assert
            Assert.Equal(_bookCatalog.Books, resultedBooks);
        }
    }
}