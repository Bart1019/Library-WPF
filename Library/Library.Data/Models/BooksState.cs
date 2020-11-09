using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class BooksState
    {
        public BooksCatalog BooksCatalog { get; set; }
        public Dictionary<int, int> AvailableBooks { get; set; } = new Dictionary<int, int>();
    }
}
