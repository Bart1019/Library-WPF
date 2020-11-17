﻿using Library.Data;
using Library.Data.Models;
using Library.Logic;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class BookEventRepositoryTests
    {
        public BookEventRepositoryTests()
        {
            dbContext = new DbContext();
            bookEventRepository = new BookEventRepository(dbContext);
        }

        private readonly BookEventRepository bookEventRepository;
        private readonly DbContext dbContext;

        [Fact]
        public void ShouldAddRentalEvent()
        {
            //Arrange
            var rentalEvent = new RentalEvent();

            //Act
            bookEventRepository.AddRentalEvent(rentalEvent);

            //Assert
        }

        [Fact]
        public void ShouldAddReturnEvent()
        {
            //Arrange
            var returnEvent = new ReturnEvent();

            //Act
            bookEventRepository.AddReturnEvent(returnEvent);

            //Assert
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
    }
}