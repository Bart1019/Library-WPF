using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Logic.Services;
using Moq;
using Xunit;

namespace Library.Tests.UnitTests.ServicesTests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> bookRepositoryMock;
        private readonly BookService bookService;
        private List<Book> books;
        private Book book = new Book();

        public BookServiceTests()
        {
            bookRepositoryMock = new Mock<IBookRepository>();
            bookService = new BookService(bookRepositoryMock.Object);
            books = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, IsAvailable = true},
                new Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman, IsAvailable = false},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, IsAvailable = false},
                new Book {Id = 4, Title = "dddd", BookType = BookEnum.Adventure, IsAvailable = true},
                new Book {Id = 5, Title = "eeee", BookType = BookEnum.Roman, IsAvailable = false},
                new Book {Id = 6, Title = "ffff", BookType = BookEnum.Document, IsAvailable = false}
            };
        }

        [Fact]
        public void ShouldGetAllBooks()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.GetAllBooks()).Returns(books);

            //Act
            var resultedBooks = bookService.GetAllBooks();

            //Assert
            Assert.Equal(resultedBooks, books);
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
            Assert.Equal(returnedBook, book);
        }

        [Theory]
        [InlineData(BookEnum.Adventure)]
        [InlineData(BookEnum.Document)]
        [InlineData(BookEnum.Roman)]
        [InlineData(default)]
        public void ShouldReturnBookByBookType(BookEnum bookType)
        {
            bookRepositoryMock.Setup(x => x.GetBookByType(It.IsAny<BookEnum>())).Returns(book);

            //Act
            var returnedBook = bookService.GetBook(bookType);

            //Assert
            Assert.Equal(returnedBook, book);
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
