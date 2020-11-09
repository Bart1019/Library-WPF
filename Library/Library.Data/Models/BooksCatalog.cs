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


    //public class Eventaa
    //{
    //    public User User { get; set; }
    //    public ShopState State { get; set; }
    //    private DateTime RentalDateTime { get; set; }

    //}

    //public class ShopState
    //{
    //    public KeyboardsCatalog Catalog { get; set; }
    //    private Dictionary<int, int> Amounts { get; set; }
    //}

    ////ShopState - ilosc dostepnych sztuk klawiatury a, b, c - np id klawiatury do ilosci

    //public class KeyboardsCatalog
    //{
    //    public List<Keyboard> Keyboards { get; set; } = new List<Keyboard>();

    //    public class Keyboard
    //    {
    //        public int Id { get; set; }
    //        public string Name { get; set; }
    //    }
    //}
}
