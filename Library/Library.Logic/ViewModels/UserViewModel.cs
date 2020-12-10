using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Library.Data;

namespace Library.Logic.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private UserRepository _userRepository = new UserRepository();

        public ObservableCollection<User> Users { get; set; }

        public UserRepository UserRepository
        {
            get { return _userRepository; }
            set
            {
                _userRepository = value;
            }
        }

        public UserViewModel()
        {
            Users = new ObservableCollection<User>(_userRepository.GetAllUsers());
        }
    }
}
