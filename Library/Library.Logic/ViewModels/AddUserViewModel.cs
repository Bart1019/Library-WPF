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
        private readonly UserListViewModel _userListViewModel;
        private ObservableCollection<User> _users;
        private string name;
        private string surname;
        private int amountOfBooksRented;
        private bool _canExecute = true;

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
                        {
                            result = "Name cannot be empty";
                            
                        }
                        break;
                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Surname))
                        {
                            result = "Surname cannot be empty";
                        }
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

                RaisePropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }

        public AddUserViewModel()
        {
            AddCommand = new RelayCommand(Add, ()=> _canExecute);
            _userListViewModel = new UserListViewModel();
            _userRepository = _userListViewModel.UserRepository;
            _users = _userListViewModel.Users;
        }

        public string Name
        {
            get { return this.name;}
            set
            {
                this.name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return this.surname; }
            set
            {
                this.surname = value;
                RaisePropertyChanged(nameof(Surname));
            }
        }

        public int AmountOfBooksRented
        {
            get { return this.amountOfBooksRented; }
            set
            {
                this.amountOfBooksRented = value;
                RaisePropertyChanged(nameof(AmountOfBooksRented));
            }
        }

        public void Add()
        {
            User user = new User
            {
                Name = Name,
                Surname = Surname,
                AmountOfBooksRented = AmountOfBooksRented
            };

            Task.Factory.StartNew(() => _userRepository.AddUser(user))
                .ContinueWith((t1) => _users = _userListViewModel.Users);

            RaisePropertyChanged(nameof(_users));
        }
    }
}
