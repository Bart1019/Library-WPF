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

        public int Id { get; set; }
        public DateTime RentalDuration { get; set; }
        private List<User> UsersRentalHistory { get; set; }
        public List<Book> BooksRentalHistory { get; set; }
    }
}
