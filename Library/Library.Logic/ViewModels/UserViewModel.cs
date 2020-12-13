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
        private UserRepository _userRepository = new UserRepository();
        private ObservableCollection<User> _users;
        private readonly bool _canExecute = true;

        public RelayCommand LoadDataCommand { get; set; }
        
        public RelayCommand DeleteCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public UserViewModel()
        {
            Task.Run(() => { Users = new ObservableCollection<User>(UserRepository.GetAllUsers()); });
            UpdateViewCommand = new UpdateUserViewCommand(this);
            LoadDataCommand = new RelayCommand(() => UserRepository = _userRepository);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
           
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
                DeleteCommand.RaiseCanExecuteChanged();
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

        public void Delete()
        {
            Task.Factory.StartNew(()=>_userRepository.DeleteUser(SelectedUser.Id))
                .ContinueWith((t1) => UserRepository = _userRepository);
        }

        private bool CanDelete()
        {
            return SelectedUser != null;
        }
    }
}
