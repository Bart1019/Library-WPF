using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class BookEventRepositoryTests
    {
        private readonly MockBookEventRepository bookEventRepository;

        public BookEventRepositoryTests()
        {
            bookEventRepository = new MockBookEventRepository();
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
