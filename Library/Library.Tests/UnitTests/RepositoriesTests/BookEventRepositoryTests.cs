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
        public void ShouldReturnAllRentals()
        {
            //Arrange

            //Act
            var returnedRentals = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(returnedRentals.Count.Equals(3));
        }
    }
}
