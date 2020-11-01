using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockRentalRepository : IRentalRepository
    {
        public IQueryable<Rental> GetAllRentals()
        {
            throw new NotImplementedException();
        }

        public Rental GetRentalById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAllRentalUsers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetAllRentedBooks()
        {
            throw new NotImplementedException();
        }
    }
}
