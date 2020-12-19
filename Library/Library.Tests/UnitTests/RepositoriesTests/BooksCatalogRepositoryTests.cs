using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Library.DataTests
{
    public class BooksCatalogRepositoryTests
    {
        private IQueryable<Book> _books;
        private readonly Mock<DbSet<Book>> _mockSet;
        private readonly Mock<LibraryDbContext> _libraryDbContextMock;
        private readonly BooksCatalogRepository _booksCatalogRepository;

        public BooksCatalogRepositoryTests()
        {
            _books = new List<Book>
            {
                new Book{ Id = 0, Title = "aaa", BookGenre = BookEnum.Adventure},
                new Book{ Id = 1, Title = "bbb", BookGenre = BookEnum.Document},
                new Book{ Id = 2, Title = "ccc", BookGenre = BookEnum.Roman},
            }.AsQueryable();

            _mockSet = new Mock<DbSet<Book>>();
            _mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(_books.Provider);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(_books.Expression);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(_books.ElementType);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(_books.GetEnumerator());

            _libraryDbContextMock = new Mock<LibraryDbContext>();
            _libraryDbContextMock.Setup(x => x.Set<Book>()).Returns(_mockSet.Object);

            _booksCatalogRepository = new BooksCatalogRepository(_libraryDbContextMock.Object);
        }

        [Fact]
        public void ShouldReturnAllBooks()
        {
            //Arrange

            //Act
            var resultedBooks = _booksCatalogRepository.GetAllBooks();

            //Assert
            Assert.Equal(3, resultedBooks.Count());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void ShouldReturnBookById(int id)
        {
            //Arrange

            //Act
            var returnedBook = _booksCatalogRepository.GetBookById(id);

            //Assert
            switch (id)
            {
                case 0:
                    Assert.Equal("aaa", returnedBook.Title);
                    break;
                case 1:
                    Assert.Equal("bbb", returnedBook.Title);
                    break;
                case 2:
                    Assert.Equal("ccc", returnedBook.Title);
                    break;
            }
        }

        [Theory]
        [InlineData(BookEnum.Adventure)]
        [InlineData(BookEnum.Document)]
        [InlineData(BookEnum.Roman)]
        public void ShouldReturnBookByBookType(BookEnum bookType)
        {
            //Arrange

            //Act
            var returnedBook = _booksCatalogRepository.GetBookByType(bookType);

            //Assert
            switch (bookType)
            {
                case BookEnum.Adventure:
                    Assert.Equal(BookEnum.Adventure, returnedBook.BookGenre);
                    break;
                case BookEnum.Document:
                    Assert.Equal(BookEnum.Document, returnedBook.BookGenre);
                    break;
                case BookEnum.Roman:
                    Assert.Equal(BookEnum.Roman, returnedBook.BookGenre);
                    break;
            }
        }

        [Fact]
        public void ShouldAddBook()
        {
            //Arrange
            var newBook = new Book
            {
                Id = 3,
                Title = "ddd",
                Author = "Ddd"
            };

            //Act
            _booksCatalogRepository.AddBook(newBook);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ShouldDeleteBook()
        {
            //Arrange

            //Act
            _booksCatalogRepository.DeleteBook(1);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ShouldEditBook()
        {
            //Arrange
            var editedBook = new Book
            {
                Id = 1,
                Title = "ddd",
                Author = "Ddd"
            };

            //Act
            _booksCatalogRepository.EditBook(editedBook);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}