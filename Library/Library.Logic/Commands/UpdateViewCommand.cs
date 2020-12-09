using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Library.Logic.ViewModels;

namespace Library.Logic.Commands
{
    class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Users")
            {
                viewModel.SelectedViewModel = new UserListViewModel();
            }
            else if (parameter.ToString() == "Books")
            {
                viewModel.SelectedViewModel = new BookCatalogViewModel();
            }
            else if (parameter.ToString() == "Events")
            {
                viewModel.SelectedViewModel = new EventListViewModel();
            }
        }
    }

}
