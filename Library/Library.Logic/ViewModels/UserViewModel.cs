using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Data;
using Library.Logic.Commands;

namespace Library.Logic.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private User _selectedUser;
        private BaseViewModel _selectedViewModel;
        private UserRepository _userRepository;
        private ObservableCollection<User> _users;
        private bool _canExecute;

        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public UserViewModel()
        {
            UpdateViewCommand = new UpdateUserViewCommand(this);
            LoadDataCommand = new RelayCommand(() => UserRepository = new UserRepository());
            DeleteCommand = new RelayCommand(Delete, ()=>true);
            AddCommand = new RelayCommand(Add, ()=> _canExecute);
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged();
            }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                RaisePropertyChanged();
               // DeleteCommand.RaiseCanExecuteChanged();
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

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int AmountOfBooksRented { get; set; }

        public void Delete()
        {
            Task.Run(() =>
            {
                _userRepository.DeleteUser(SelectedUser.Id);
            });
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

            Task.Run(() => { _userRepository.AddUser(user); });
            RaisePropertyChanged(nameof(Users));
        }

        private bool CanDelete()
        {
            return SelectedUser != null;
        }
    }
}
