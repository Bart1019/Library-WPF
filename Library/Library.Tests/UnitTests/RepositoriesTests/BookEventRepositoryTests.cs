using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Logic;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class BookEventRepositoryTests
    {
        private readonly MockBookEventRepository bookEventRepository;
        private readonly MockDbContext dbContext;

        public BookEventRepositoryTests()
        {
            dbContext = new MockDbContext();
            bookEventRepository = new MockBookEventRepository(dbContext);
        }

        [Fact]
        public void ShouldReturnAllEvents()
        {
            //Arrange

            //Act
            var returnedRentals = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(returnedRentals.Count.Equals(3));
        }

        [Fact]
        public void ShouldAddRentalEvent()
        {
            //Arrange
            RentalEvent rentalEvent = new RentalEvent();

            //Act
            bookEventRepository.AddRentalEvent(rentalEvent);

            //Assert
        }

        [Fact]
        public void ShouldAddReturnEvent()
        {
            //Arrange
            ReturnEvent returnEvent = new ReturnEvent();

            //Act
            bookEventRepository.AddReturnEvent(returnEvent);

            //Assert
        }
    }
}
