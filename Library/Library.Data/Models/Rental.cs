using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class Rental
    {
        private User user;
        private Book book;

        public Rental(User user, Book book)
        {
            this.user = user;
            this.book = book;
        }

        public Dictionary<Book, User> RentedBooks { get; set; }
        //Todo rethink how this class should work
    }
}
