using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Data
{
    public class DataContext
    {
        public List<User> Users = new List<User>();
        public List<BookEvent> BookEvents = new List<BookEvent>();
        public BookState BookState = new BookState();
        public BookCatalog BookCatalog = new BookCatalog();
    }
}