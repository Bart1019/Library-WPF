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

        public RelayCommand DeleteCommand { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public UserViewModel()
        {
            UpdateViewCommand = new UpdateUserViewCommand(this);
            Users = new ObservableCollection<User>(UserRepository.GetAllUsers());
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        public UserRepository UserRepository { get; set; } = new UserRepository();

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                DeleteCommand.RaiseCanExecuteChanged();
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

        private void OnDelete()
        {
            Users.Remove(SelectedUser);
        }

        private bool CanDelete()
        {
            return SelectedUser != null;
        }

        public void Delete()
        {
            Task.Run(() =>
            {
                Users.Remove(SelectedUser);
            });
            OnPropertyChanged(nameof(Users));
        }
    }
}
