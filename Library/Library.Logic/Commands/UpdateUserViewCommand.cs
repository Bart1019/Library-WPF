using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Library.Logic.ViewModels;

namespace Library.Logic.Commands
{
    public class UpdateUserViewCommand : ICommand
    {
        private readonly UserListViewModel _listViewModel;

        public UpdateUserViewCommand(UserListViewModel listViewModel)
        {
            _listViewModel = listViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Add")
            {
                _listViewModel.SelectedViewModel = new AddUserViewModel();
            }
            else if (parameter.ToString() == "Edit")
            {
                _listViewModel.SelectedViewModel = new EditUserViewModel();
            }
        }
    }
}
