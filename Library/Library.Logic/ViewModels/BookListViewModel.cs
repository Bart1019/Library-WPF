using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Data;
using Library.Logic.Commands;

namespace Library.Logic.ViewModels
{
    public class BookListViewModel : BaseViewModel, IDataErrorInfo
    {
        #region private
        private Book _selectedBook = new Book();
        private BooksCatalogRepository _bookRepository = new BooksCatalogRepository();
        private ObservableCollection<Book> _books;
        private string _title;
        private string _author;
        private BookEnum _bookGenre;
        private bool _canExecute = true;
        #endregion

        #region properties
        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        #endregion


        public BookListViewModel()
        {
            Task.Run(() =>
            {
                Books = new ObservableCollection<Book>(BookRepository.GetAllBooks());
            });
            AddCommand = new RelayCommand(Add, () => _canExecute);
            LoadDataCommand = new RelayCommand(() => BookRepository = new BooksCatalogRepository());
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            EditCommand = new RelayCommand(Edit, () => _canExecute);
        }

        #region errors
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
                    case "Title":
                        if (string.IsNullOrWhiteSpace(Title))
                        {
                            result = "Title cannot be empty";

                        }
                        break;
                    case "Author":
                        if (string.IsNullOrWhiteSpace(Author))
                        {
                            result = "Author cannot be empty";
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

                RaisePropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }
        #endregion

        #region implementedProperties
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                RaisePropertyChanged(nameof(Books));
            }
        }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                RaisePropertyChanged(nameof(SelectedBook));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public BooksCatalogRepository BookRepository
        {
            get { return _bookRepository; }
            set
            {
                _bookRepository = value;
                Books = new ObservableCollection<Book>(value.GetAllBooks());
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                RaisePropertyChanged(nameof(Author));
            }
        }

        public BookEnum BookGenre
        {
            get { return _bookGenre; }
            set
            {
                _bookGenre = value;
                RaisePropertyChanged(nameof(BookGenre));
            }
        }
        #endregion

        #region commands
        public void Delete()
        {
            Task.Factory.StartNew(() => _bookRepository.DeleteBook(SelectedBook.Id))
                .ContinueWith((t1) => BookRepository = _bookRepository);

            RaisePropertyChanged(nameof(Books));
        }

        public void Add()
        {
            Book book = new Book
            {
                Title = Title,
                Author = Author,
                BookGenre = BookGenre
            };

            Task.Factory.StartNew(() => _bookRepository.AddBook(book))
                .ContinueWith((t1) => BookRepository = _bookRepository);

            RaisePropertyChanged(nameof(Books));
        }

        public void Edit()
        {
            Book book = new Book
            {
                Id = SelectedBook.Id,
                Title = Title,
                Author = Author,
                BookGenre = BookGenre
            };

            Task.Factory.StartNew(() => _bookRepository.EditBook(book))
                .ContinueWith((t1) => BookRepository = _bookRepository);

            RaisePropertyChanged(nameof(Books));
        }
        #endregion


        private bool CanDelete()
        {
            return SelectedBook != null;
        }
    }
}
