using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library.Data;
using Library.Logic.Commands;

namespace Library.Logic.ViewModels
{
    public class AddUserViewModel : ErrorBaseViewModel
    {
       
        private readonly UserRepository _userRepository;
        private string name;
        private string surname;
        private int amountOfBooksRented;

        public RelayCommand AddCommand { get; set; }

        public AddUserViewModel()
        {
            AddCommand = new RelayCommand(Add, () => true);
            var userViewModel = new UserViewModel();
            _userRepository = userViewModel.UserRepository;
        }

        public string Name
        {
            get { return this.name;}
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return this.surname; }
            set
            {
                this.surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public int AmountOfBooksRented
        {
            get { return this.amountOfBooksRented; }
            set
            {
                this.amountOfBooksRented = value;
                OnPropertyChanged(nameof(AmountOfBooksRented));
            }
        }

        public void Add()
        {
            User user = new User
            {
                Name = "Franek",
                Surname = "Kimono",
                AmountOfBooksRented = 3
            };

            Task.Factory.StartNew(() => _userRepository.AddUser(user))
                .ContinueWith((t1) => _userRepository.GetAllUsers());
        }
    }
}
