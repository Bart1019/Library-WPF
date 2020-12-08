using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class User : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private int _amountOfBooksRented;

        [Key]
        public int Id { get; set; }
        public string Name 
        { 
            get => _name;

            set 
            {
                if (_name == value) return;
                _name = value; 
                RaisePropertyChanged("Name");
                RaisePropertyChanged("FullName");
            } 
        }
        public string Surname
        {
            get => _surname;

            set
            {
                if (_surname == value) return;
                _surname = value;
                RaisePropertyChanged("Surname");
                RaisePropertyChanged("FullName");
            }
        }

        public int AmountOfBooksRented
        {
            get => _amountOfBooksRented;

            set
            {
                if (_amountOfBooksRented == value) return;
                _amountOfBooksRented = value;
                RaisePropertyChanged("AmountOfBooksRented");
            }
        }



        public string FullName
        {
            get
            {
                return _name + " " + _surname;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}