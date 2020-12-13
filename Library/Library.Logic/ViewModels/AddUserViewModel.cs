using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library.Data;
using Library.Logic.Commands;

namespace Library.Logic.ViewModels
{
    public class AddUserViewModel : BaseViewModel, IDataErrorInfo
    {
       
        private UserRepository _userRepository;
        private readonly UserViewModel _userViewModel;
        private User user;
        private string name;
        private string surname;
        private int amountOfBooksRented;

        public RelayCommand AddCommand { get; set; }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Name cannot be empty";
                        break;
                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Surname))
                            result = "Surname cannot be empty";
                        break;
                    case "AmountOfBooksRented":
                        if (AmountOfBooksRented.Equals(null))
                            result = "Rented Books cannot be empty";
                        break;
                }

                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                }
                else if(result != null)
                {
                    ErrorCollection.Add(columnName, result);
                }

                OnPropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }


        public AddUserViewModel()
        {
            AddCommand = new RelayCommand(Add, CanAdd);
            _userViewModel = new UserViewModel();
            _userRepository = _userViewModel.UserRepository;
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

        public User User
        {
            get { return this.user; }
            set
            {
                this.user = value;
                RaisePropertyChanged();
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public void Add()
        {
            User = new User
            {
                Name = Name,
                Surname = Surname,
                AmountOfBooksRented = AmountOfBooksRented
            };

            Task.Factory.StartNew(() => _userRepository.AddUser(User))
                .ContinueWith((t1) => _userRepository = new UserRepository());
        }

        private bool CanAdd()
        {
            if (ErrorCollection.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
