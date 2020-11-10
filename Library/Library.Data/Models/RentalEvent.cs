using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class RentalEvent : BookEvent
    {
        public BooksState BooksInLibrary { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
