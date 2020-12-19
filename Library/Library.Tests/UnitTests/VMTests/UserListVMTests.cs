using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;
using Library.Logic.ViewModels;
using Xunit;

namespace Library.VmTests
{
    public class UserListVMTests
    {
        private readonly UserListViewModel _userListViewModel;

        public UserListVMTests()
        {
            _userListViewModel = new UserListViewModel();
        }

        [Fact]
        public void VmShouldInitializeCommandsAndUserGridVm()
        {
            //Arrange

            //Act
            var addCommand = _userListViewModel.AddCommand;
            var editCommand = _userListViewModel.EditCommand;
            var deleteCommand = _userListViewModel.DeleteCommand;

            //Assert
            Assert.NotNull(addCommand);
            Assert.NotNull(editCommand);
            Assert.NotNull(deleteCommand);
        }

        [Fact]
        public void AddCmdShouldNotBeExecuted()
        {
            //Arrange

            //Act


            //Assert
            
        }

        [Fact]
        public void AddCmdShouldBeExecuted()
        {
            //Arrange
            var user = new User
            {
                Name = "aaa",
                Surname = "aaa"
            };

            //Act
            var canBeExecuted = _userListViewModel.AddCommand.CanExecute(null);

            //Assert
            Assert.True(canBeExecuted);
        }

        [Fact]
        public void DeleteCmdShouldNotBeExecuted()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void DeleteCmdShouldBeExecuted()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void EditCmdShouldNotBeExecuted()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void EditCmdShouldBeExecuted()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
