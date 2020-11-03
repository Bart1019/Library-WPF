using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Data.Models;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class UserRepositoryTests
    {
        private readonly MockUserRepository userRepository;

        public UserRepositoryTests()
        {
            userRepository = new MockUserRepository();
        }

        [Fact]
        public void ShouldReturnAllUsers()
        {
            //Arrange

            //Act
            var returnedUsers = userRepository.GetAllUsers();

            //Assert
            Assert.True(returnedUsers.Count.Equals(6));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(6)]
        public void ShouldReturnUserById(int id)
        {
            //Arrange
            List<User> expectedUsers = new List<User>
            {
                new User {Id = 1, Name = "aaa", Surname = "aaaa", AmountOfBooksRented = 1},
                new User {Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 3},
                new User {Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6}
            };

            //Act
            var returnedUser = userRepository.GetUserById(id);

            //Assert
            switch (id)
            {
                case 1:
                    Assert.Equal(expectedUsers[0].Id, returnedUser.Id);
                    break;
                case 3:
                    Assert.Equal(expectedUsers[1].Id, returnedUser.Id);
                    break;
                case 6:
                    Assert.Equal(expectedUsers[2].Id, returnedUser.Id);
                    break;
            }
        }

        [Fact]
        public void ShouldDeleteUser()
        {
            //Arrange

            //Act
            userRepository.DeleteUser(1);

            var books = userRepository.GetAllUsers();

            //Assert
            Assert.True(books.Count.Equals(5));
        }

        [Fact]
        public void ShouldEditUser()
        {
            //Arrange
            User expectedUser = new User
            {
                Id = 1,
                Name = "fff",
                Surname = "fff",
                AmountOfBooksRented = 30
            };

            //Act
            userRepository.EditUser(expectedUser);

            var user = userRepository.GetUserById(expectedUser.Id);

            //Assert
            Assert.Equal(expectedUser.Id, user.Id);
            Assert.Equal(expectedUser.Name, user.Name);
            Assert.Equal(expectedUser.Surname, user.Surname);
            Assert.Equal(expectedUser.AmountOfBooksRented, user.AmountOfBooksRented);
        }

        [Fact]
        public void ShouldAddUser()
        {
            //Arrange
            User newUser = new User
            {
                Id = 7,
                Name = "fff",
                Surname = "fff",
                AmountOfBooksRented = 30
            };

            //Act
            userRepository.AddUser(newUser);

            var users = userRepository.GetAllUsers();

            //Assert
            Assert.True(users.Count.Equals(7));
        }
    }
}
