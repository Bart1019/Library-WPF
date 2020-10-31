using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class Rental
    {
        public Dictionary<Book, User> RentedBooks { get; set; }
        //Todo rethink how this class should work
    }
}
