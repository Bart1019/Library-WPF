using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class Rental
    {
        private User user;
        private OurLibrary library;

        public Rental(User user, OurLibrary library)
        {
            this.user = user;
            this.library = library;
        }

        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime GiveBackDate { get; set; }
        public List<User> UsersRentalHistory { get; set; }
    }
}
