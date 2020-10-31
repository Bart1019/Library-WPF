using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IRentalRepository
    {
        Dictionary<Book, User> GetAllRentals();
        Dictionary<Book, User> GetRentalById(int id);
    }
}
