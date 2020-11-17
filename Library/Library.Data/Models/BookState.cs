using System.Collections.Generic;

namespace Library.Data.Models
{
    public class BookState
    {
        public Dictionary<int, int> AvailableBooksAmount { get; set; } = new Dictionary<int, int>();
        public BookCatalog AvailableBook { get; set; }
    }
}