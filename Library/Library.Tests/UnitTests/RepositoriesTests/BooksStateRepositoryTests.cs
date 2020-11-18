﻿using Library.Data;
using Library.Data.Repositories;
using Library.Logic;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.Data.UnitTests.RepositoriesTests
{
    public class BooksStateRepositoryTests
    {
        public BooksStateRepositoryTests()
        {
            dbContext = new DbContext();
            booksStateRepository = new BooksStateRepository(dbContext);
        }

        private readonly BooksStateRepository booksStateRepository;
        private readonly DbContext dbContext;

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
        public void ShouldGetAllAvailableBooks()
        {
            //Arrange

            //Act
            var resultedBooks = booksStateRepository.GetAllAvailableBooks();

            //Assert
            Assert.True(resultedBooks.Count.Equals(6));
        }

        [Fact]
        public void ShouldUpdateBooksAmount()
        {
            //Arrange
            var expectedAmountOfBooks = 33;

            //Act
            var actualAmountOfBooks = booksStateRepository.UpdateBooksAmount(1, 33);

            //Assert
            Assert.Equal(expectedAmountOfBooks, actualAmountOfBooks);
        }
    }
}