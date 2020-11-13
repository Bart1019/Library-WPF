using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Logic.Repositories;
using Xunit;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class BooksStateRepositoryTests
    {
        private readonly MockBooksStateRepository booksStateRepository;

        public BooksStateRepositoryTests()
        {
            booksStateRepository = new MockBooksStateRepository();
        }

        [Fact]
        public void ShouldGetAllAvailableBooks()
        {
            //Arrange

            //Act
            var resultedBooks = booksStateRepository.GetAllAvailableBooks();

            //Assert
            Assert.True(resultedBooks.Count.Equals(6));

        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(default)]
        public void ShouldGetAmountOfAvailableBooksById(int id)
        {
            //Arrange
            int expectedAmountOfBooks;

            //Act
            var resultedAmountOfBooks = booksStateRepository.GetAmountOfAvailableBooksById(id);

            //Assert
            switch (id)
            {
                case 1:
                    expectedAmountOfBooks = 32;
                        Assert.Equal(expectedAmountOfBooks, resultedAmountOfBooks);
                    break;
                case 3:
                    expectedAmountOfBooks = 18;
                        Assert.Equal(expectedAmountOfBooks, resultedAmountOfBooks);
                    break;
                case 5:
                    expectedAmountOfBooks = 2;
                        Assert.Equal(expectedAmountOfBooks, resultedAmountOfBooks);
                    break;
                case 0:
                    expectedAmountOfBooks = 0;
                        Assert.Equal(expectedAmountOfBooks, resultedAmountOfBooks);
                    break;
            }
        }

        [Fact]
        public void ShouldUpdateBooksAmount()
        {
            //Arrange
            int expectedAmountOfBooks = 33;

            //Act
            var actualAmountOfBooks = booksStateRepository.UpdateBooksAmount(1, 33);

            //Assert
            Assert.Equal(expectedAmountOfBooks,actualAmountOfBooks);
        }
    }
}
