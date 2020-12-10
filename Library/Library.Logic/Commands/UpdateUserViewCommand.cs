using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Library.Logic.ViewModels;

namespace Library.Logic.Commands
{
    public class UpdateUserViewCommand : ICommand
    {
        private readonly UserViewModel _viewModel;

        public UpdateUserViewCommand(UserViewModel viewModel)
        {
            _viewModel = viewModel;
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
                _viewModel.SelectedViewModel = new AddUserViewModel();
            }
            else if (parameter.ToString() == "Edit")
            {
                _viewModel.SelectedViewModel = new EditUserViewModel();
            }
        }
    }
}
