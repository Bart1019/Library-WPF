using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Library.Data;

namespace Library.Logic.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
    }
}
