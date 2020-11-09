using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Interfaces;

namespace Library.Data.Models
{
    public class BookEvent
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime GiveBackDate { get; set; }
        public EventEnum EventType { get; set; }
        public User RentalUser { get; set; }
        public BooksState BooksInLibrary { get; set; }
    }
}
