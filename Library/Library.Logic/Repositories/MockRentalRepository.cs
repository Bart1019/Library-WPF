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
        private List<Rental> rentals;

        public MockRentalRepository()
        {
            rentals = new List<Rental>
            {
                new Rental { Id = 1, RentalDate = default, GiveBackDate = default, RentedBooksHistory = default, RentalUsersHistory = default},
                new Rental { Id = 2, RentalDate = default, GiveBackDate = default, RentedBooksHistory = default, RentalUsersHistory = default},
                new Rental { Id = 3, RentalDate = default, GiveBackDate = default, RentedBooksHistory = default, RentalUsersHistory = default}
            };
        }

        public IQueryable<Rental> GetAllRentals()
        {
            return rentals.AsQueryable();
        }

        public Rental GetRentalById(int id)
        {
            return rentals.FirstOrDefault(i => i.Id.Equals(id));
        }

        public IQueryable<User> GetAllRentalUsers(int id)
        {
            Rental rental = rentals.FirstOrDefault(i => i.Id.Equals(id));

            return rental.RentalUsersHistory.AsQueryable();
        }

        public IQueryable<Book> GetAllRentedBooks(int id)
        {
            Rental rental = rentals.FirstOrDefault(i => i.Id.Equals(id));

            return rental.RentedBooksHistory.AsQueryable();
        }
    }
}
