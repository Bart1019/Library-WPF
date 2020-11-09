using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class BooksCatalog
    {
        public List<Book> Books { get; set; }

        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public BookEnum BookType { get; set; }
        }
    }
}
