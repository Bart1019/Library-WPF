using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Tests.Data.UnitTests.DataGenerators;
using Xunit;

namespace Library.Tests.Data.UnitTests.DataGenerationTests
{
    public class RandomDataGeneratorTests
    {
        private readonly RandomDataGenerator randomDataGenerator;

        public RandomDataGeneratorTests()
        {
            randomDataGenerator = new RandomDataGenerator();
        }

        [Fact]
        public void ShouldReturnUserType()
        {
            //Arrange

            //Act
            var returnedUser = randomDataGenerator.CreateRandomUser();

            //Assert
            Assert.IsType<User>(returnedUser);
        }

        [Fact]
        public void ShouldReturnBookType()
        {
            //Arrange

            //Act
            var returnedBook = randomDataGenerator.CreateRandomBook();

            //Assert
            Assert.IsType<Book>(returnedBook);
        }

        [Fact]
        public void ShouldReturnStateType()
        {
            //Arrange

            //Act
            var randomBookState = randomDataGenerator.CreateRandomBookState();

            //Assert
            Assert.IsType<BookState>(randomBookState);
        }

        [Fact]
        public void ShouldReturnRentalEventType()
        {
            //Arrange

            //Act
            var randomRentalEvent = randomDataGenerator.CreateRandomRentalEvent();

            //Assert
            Assert.IsType<RentalEvent>(randomRentalEvent);
        }

        [Fact]
        public void ShouldReturnReturnEventType()
        {
            //Arrange

            //Act
            var randomReturnEvent = randomDataGenerator.CreateRandomReturnEvent();

            //Assert
            Assert.IsType<ReturnEvent>(randomReturnEvent);
        }
    }
}
