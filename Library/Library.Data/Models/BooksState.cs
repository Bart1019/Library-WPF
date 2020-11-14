using System.Collections.Generic;

namespace Library.Data.Models
{
    public class BooksState
    {
        public Dictionary<int, int> AvailableBooks { get; set; } = new Dictionary<int, int>();
        public BooksCatalog BooksCatalog { get; set; }
    }
}