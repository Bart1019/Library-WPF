using System;
using System.Collections.Generic;
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
    public class BooksCatalogServiceTests
    {
        private readonly Mock<IBooksCatalogRepository> bookRepositoryMock;
        private readonly BooksCatalogService bookService;
        private readonly Book book = new Book();
        private BooksCatalog booksCatalog = new BooksCatalog();

        public BooksCatalogServiceTests()
        {
            bookRepositoryMock = new Mock<IBooksCatalogRepository>();
            bookService = new BooksCatalogService(bookRepositoryMock.Object);
            booksCatalog.Books = new List<Book>
            {
                new Book { Id = 1, Title = "aaaa", BookType = BookEnum.Adventure },
                new Book { Id = 2, Title = "bbbb", BookType = BookEnum.Roman },
                new Book { Id = 3, Title = "cccc", BookType = BookEnum.Document },
                new Book { Id = 4, Title = "dddd", BookType = BookEnum.Adventure },
                new Book { Id = 5, Title = "eeee", BookType = BookEnum.Roman },
                new Book { Id = 6, Title = "ffff", BookType = BookEnum.Document }
            };
        }

        [Fact]
        public void ShouldGetAllBooks()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.GetAllBooks()).Returns(booksCatalog.Books);

            //Act
            var resultedBooks = bookService.GetAllBooks();

            //Assert
            Assert.Equal(booksCatalog.Books, resultedBooks);
        }

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
            bookRepositoryMock.Setup(x => x.EditBook(It.IsAny<Book>()));
            

            //Act
            bookService.EditBook(default);

            //Assert
        }

        [Fact]
        public void ShouldAddBook()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.AddBook(It.IsAny<Book>()));

            //Act
            bookService.AddBook(default);

            //Assert
        }
    }
}
