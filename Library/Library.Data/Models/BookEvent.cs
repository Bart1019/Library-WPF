using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Interfaces;

namespace Library.Data.Models
{
    public abstract class BookEvent
    {
        public User RentalUser { get; set; }
    }
}
