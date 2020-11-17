using System.Collections.Generic;

namespace Library.Data.Models
{
    public class BookState
    {
        public Dictionary<Book, int> AvailableBooksAmount { get; set; } = new Dictionary<Book, int>();
        public BookCatalog AllBooks { get; set; }
    }
}