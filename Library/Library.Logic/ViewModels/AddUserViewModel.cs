using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Logic.Commands;

namespace Library.Logic.ViewModels
{
    public class AddUserViewModel : ErrorBaseViewModel
    {
        private readonly ObservableCollection<User> _users;
        private readonly UserRepository _userRepository;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AmountOfBooksRented { get; set; }
        public RelayCommand AddCommand { get; set; }

        public AddUserViewModel()
        {
            AddCommand = new RelayCommand(Add, () => true);
            var userViewModel = new UserViewModel();
            _users = userViewModel.Users;
            _userRepository = userViewModel.UserRepository;
        }

        public void Add()
        {
            User user = new User
            {
                Name = "Andy",
                Surname = "Marshal",
                AmountOfBooksRented = 2
            };

            _userRepository.AddUser(user);
        }
    }
}
