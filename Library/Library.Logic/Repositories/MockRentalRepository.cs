﻿using System;
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

        public void DeleteRental(int id)
        {
            Rental deletedRental = rentals.FirstOrDefault(i => i.Id.Equals(id));

            if(deletedRental != null)
            {
                rentals.Remove(deletedRental);
            }
        }

        public void EditRental(Rental rental)
        {
            Rental editedRental = rentals.FirstOrDefault(r => r.Id.Equals(rental.Id));

            if (editedRental != null)
            {
                editedRental.RentalDate = rental.RentalDate;
                editedRental.GiveBackDate = rental.GiveBackDate;
                editedRental.RentalUsersHistory = rental.RentalUsersHistory;
                editedRental.RentedBooksHistory = rental.RentedBooksHistory;
            }
        }

        public void AddRental(Rental rental)
        {
            Rental addedRental = new Rental
            {
                Id = rental.Id,
                RentalDate = rental.RentalDate,
                GiveBackDate = rental.GiveBackDate,
                RentalUsersHistory = rental.RentalUsersHistory,
                RentedBooksHistory = rental.RentedBooksHistory
            };

            rentals.Add(addedRental);
        }
    }
}
