using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IRentalRepository
    {
        IQueryable<Rental> GetAllRentals();
        Rental GetRentalById(int id);
        IQueryable<User> GetAllRentalUsers(int id);
        IQueryable<Book> GetAllRentedBooks(int id);
        void DeleteRental(int id);
        void EditRental(Rental rental);
        void AddRental(Rental rental);
    }
}
