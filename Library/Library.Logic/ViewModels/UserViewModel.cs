﻿using System;
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

        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public UserViewModel()
        {
            UpdateViewCommand = new UpdateUserViewCommand(this);
            //Users = new ObservableCollection<User>(UserRepository.GetAllUsers());
            LoadDataCommand = new RelayCommand(() => UserRepository = new UserRepository());
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

        private void OnDelete()
        {
            Users.Remove(SelectedUser);
        }

        private bool CanDelete()
        {
            return _selectedUser != null;
        }

        public void Delete()
        {
            Task.Run(() =>
            {
                Users.Remove(SelectedUser);
            });
            RaisePropertyChanged(nameof(Users));
        }
    }
}
