using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class Book
    {
        public BookEnum BookType { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
