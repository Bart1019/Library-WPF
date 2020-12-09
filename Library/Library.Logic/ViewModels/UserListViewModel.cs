using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Library.Data;

namespace Library.Logic.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public ObservableCollection<User> Users { get; set; }

        public UserListViewModel()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User {Id = 1, Name = "aaa", Surname = "aaa", AmountOfBooksRented = 1},
                new User {Id = 2, Name = "bbb", Surname = "bbb", AmountOfBooksRented = 4},
                new User {Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 5}
            };

            Users = users;
        }
    }
}
