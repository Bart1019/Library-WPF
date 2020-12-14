using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Logic.Commands;

namespace Library.Logic.ViewModels
{
    public class EditUserViewModel : BaseViewModel, IDataErrorInfo
    {
        private UserRepository _userRepository;
        private readonly UserListViewModel _userListViewModel;
        private User user;
        private int id;
        private string name;
        private string surname;
        private int amountOfBooksRented;
        private bool _canExecute = true;

        public RelayCommand EditCommand { get; set; }
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
                else if (result != null)
                {
                    ErrorCollection.Add(columnName, result);
                }

                OnPropertyChanged(nameof(ErrorCollection));
                return result;
            }

        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public EditUserViewModel()
        {
            EditCommand = new RelayCommand(Edit, ()=> _canExecute);
            _userListViewModel = new UserListViewModel();
            _userRepository = _userListViewModel.UserRepository;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Surname
        {
            get { return this.surname; }
            set
            {
                this.surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public int AmountOfBooksRented
        {
            get { return this.amountOfBooksRented; }
            set
            {
                this.amountOfBooksRented = value;
                OnPropertyChanged(nameof(AmountOfBooksRented));
            }
        }

        public User User
        {
            get {return user;}
            set
            {
                this.user = value; 
                OnPropertyChanged(nameof(User));
            }

        }

        public void Edit()
        {
            User = new User
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                AmountOfBooksRented = AmountOfBooksRented
            };

            //Task.Factory.StartNew(() => _userRepository.EditUser(User))
             //   .ContinueWith((t1) => _userRepository = new UserRepository());

             Task.Run(() =>
             {
                 _userRepository.EditUser(User);
             });

            RaisePropertyChanged(nameof(_userListViewModel.Users));
        }
    }
}
