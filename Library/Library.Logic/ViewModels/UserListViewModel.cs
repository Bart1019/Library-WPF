using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Data;
using Library.Logic.Commands;

namespace Library.Logic.ViewModels
{
    public class UserListViewModel : BaseViewModel, IDataErrorInfo
    {
        #region private
        private User _selectedUser;
        private UserRepository _userRepository = new UserRepository(new LibraryDbContext());
        private ObservableCollection<User> _users;
        private string _name;
        private string _surname;
        private int _amountOfBooksRented;
        #endregion

        #region properties
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        #endregion


        public UserListViewModel()
        {
            Task.Run(() =>
            {
                Users = new ObservableCollection<User>(UserRepository.GetAllUsers());
            });
            AddCommand = new RelayCommand(Add, ()=> CanAdd);
            DeleteCommand = new RelayCommand(Delete, CanExecute);
            EditCommand = new RelayCommand(Edit, CanExecute);
        }

        #region errors
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
                else if (result != null)
                {
                    ErrorCollection.Add(columnName, result);
                }

                RaisePropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }
        #endregion

        #region implementedProperties
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                RaisePropertyChanged(nameof(SelectedUser));
                DeleteCommand.RaiseCanExecuteChanged();
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public UserRepository UserRepository
        {
            get { return _userRepository; }
            set
            {
                _userRepository = value;
                Users = new ObservableCollection<User>(value.GetAllUsers());
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                RaisePropertyChanged(nameof(Surname));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public int AmountOfBooksRented
        {
            get { return _amountOfBooksRented; }
            set
            {
                _amountOfBooksRented = value;
                RaisePropertyChanged(nameof(AmountOfBooksRented));
            }
        }
        #endregion

        #region commands
        public void Delete()
        {
            Task.Factory.StartNew(() => _userRepository.DeleteUser(SelectedUser.Id))
                .ContinueWith((t1) => UserRepository = _userRepository);

            RaisePropertyChanged(nameof(Users));
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
                .ContinueWith((t1) => UserRepository = _userRepository);

            RaisePropertyChanged(nameof(Users));
        }

        public void Edit()
        {
            User user = new User
            {
                Id = SelectedUser.Id,
                Name = Name,
                Surname = Surname,
                AmountOfBooksRented = AmountOfBooksRented
            };

            Task.Factory.StartNew(() => _userRepository.EditUser(user))
                .ContinueWith((t1) => UserRepository = _userRepository);

            RaisePropertyChanged(nameof(Users));
        }
        #endregion

        private bool CanExecute()
        {
            return SelectedUser != null;
        }

        private bool CanAdd
        {
            get { return !(((string.IsNullOrEmpty(this.Name)) || (string.IsNullOrEmpty(this.Surname)))); }
        }
    }
}
