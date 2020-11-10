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
        private readonly MockBooksStateRepository _booksStateRepository;

        public BooksStateRepositoryTests()
        {
            _booksStateRepository = new MockBooksStateRepository();
        }

        [Fact]
        public void ShouldGetAllAvailableBooks()
        {
            //Arrange

            //Act
            var resultedBooks = _booksStateRepository.GetAllAvailableBooks();

            //Assert
            Assert.True(resultedBooks.Count.Equals(6));

        }

        [Fact]
        public void ShouldUpdateBooksAmount()
        {
            //Arrange

            //Act
            _booksStateRepository.UpdateBooksAmount(1, 33);

            //Assert
        }
    }
}
