using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockRentalRepository: IRentalRepository
    {
        private Dictionary<Book, User> _rentalDictionary;

        public MockRentalRepository()
        {
            _rentalDictionary = new Dictionary<Book, User>
            {
                [new Book { Id = 1 }] = new User { Id = 1, AmountOfBooksRented = 3 },
                [new Book { Id = 2 }] = new User { Id = 1 },
                [new Book { Id = 3 }] = new User { Id = 1 },
                [new Book { Id = 1 }] = new User { Id = 2 }

            };
        }

        public Dictionary<Book, User> GetAllRentals()
        {
            return _rentalDictionary;
        }

        public Dictionary<Book, User> GetRentalById(int id)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
