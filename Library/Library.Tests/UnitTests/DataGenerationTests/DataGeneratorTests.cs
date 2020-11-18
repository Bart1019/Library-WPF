using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Tests.Data.UnitTests.DataGenerators;
using Xunit;

namespace Library.Tests.Data.UnitTests.DataGenerationTests
{
    public class DataGeneratorTests
    {
        private DataContext dataContext;
        private DataGenerator dataGenerator;

        public DataGeneratorTests()
        {
            dataGenerator = new DataGenerator();
            dataContext = dataGenerator.GenerateData();
        }

        [Fact]
        public void ShouldReturnProperAmountOfUsers()
        {
            //Arrange

            //Act
            var returnedUsers = dataContext.Users;

            //Assert
            Assert.True(returnedUsers.Count.Equals(6));
        }

        [Fact]
        public void ShouldReturnProperAmountOfBooksFromCatalog()
        {
            //Arrange

            //Act
            var returnedBooks = dataContext.BookCatalog.Books;

            //Assert
            Assert.True(returnedBooks.Count.Equals(6));
        }

        [Fact]
        public void ShouldReturnProperAmountOfBooksFromState()
        {
            //Arrange

            //Act
            var returnedBooks = dataContext.BookState.AllBooks;

            //Assert
            Assert.True(returnedBooks.Books.Count.Equals(6));
        }

        [Fact]
        public void ShouldReturnProperAmountOfEvents()
        {
            //Arrange

            //Act
            var returnedEvents = dataContext.BookEvents;

            //Assert
            Assert.True(returnedEvents.Count.Equals(5));
        }
    }
}
