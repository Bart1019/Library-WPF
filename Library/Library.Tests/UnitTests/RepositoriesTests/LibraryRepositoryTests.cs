using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class LibraryRepositoryTests
    {
        private readonly MockLibraryRepository libraryRepository;
        public LibraryRepositoryTests()
        {
            libraryRepository = new MockLibraryRepository();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldReturnAllAvailableOrAllUnavailableBasedOnCondition(bool isAvailable)
        {
            //Arrange
            List<Book> books = new List<Book>();

            switch (isAvailable)
            {
                case true:
                    //Act
                    books = libraryRepository.GetAllAvailableBooks();

                    //Assert
                    Assert.True(books.Count.Equals(2));
                    break;

                case false:
                    //Act
                    books = libraryRepository.GetAllUnavailableBooks();

                    //Assert
                    Assert.True(books.Count.Equals(4));
                    break;
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldUpdateBookWithProperlyChangedState(bool isAvailable)
        {
            //Arrange
            List<Book> availableBooks = new List<Book>();
            List<Book> unavailableBooks = new List<Book>();

            Book availableBook = new Book
            {
                Id = 1,
                Title = "aaaa",
                BookType = BookEnum.Adventure,
                IsAvailable = true
            };

            Book unavailableBook = new Book
            {
                Id = 2,
                Title = "aaaa",
                BookType = BookEnum.Adventure,
                IsAvailable = true
            };

            switch (isAvailable)
            {
                case true:
                    //Act
                    libraryRepository.UpdateBookState(unavailableBook, isAvailable);
                    availableBooks = libraryRepository.GetAllAvailableBooks();
                    unavailableBooks = libraryRepository.GetAllUnavailableBooks();

                    //Assert
                    Assert.True(availableBooks.Count.Equals(3));
                    Assert.True(unavailableBooks.Count.Equals(3));
                    break;

                case false:
                    //Act
                    libraryRepository.UpdateBookState(availableBook, isAvailable);
                    availableBooks = libraryRepository.GetAllAvailableBooks();
                    unavailableBooks = libraryRepository.GetAllUnavailableBooks();

                    //Assert
                    Assert.True(availableBooks.Count.Equals(1));
                    Assert.True(unavailableBooks.Count.Equals(5));
                    break;
            }
        }
    }
}
