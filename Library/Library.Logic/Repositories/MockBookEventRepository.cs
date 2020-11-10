using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockBookEventRepository : IBookEventRepository
    {
        private List<BookEvent> bookEvents;

        public MockBookEventRepository()
        {
            bookEvents = new List<BookEvent>
            {
                new RentalEvent { RentalDate = default, RentalUser = default, BooksInLibrary = default },
                new RentalEvent { RentalDate = default, RentalUser = default, BooksInLibrary = default },
                new ReturnEvent { ReturnDate = default, RentalUser = default },
            };
        }

        public List<BookEvent> GetAllBookEvents()
        {
            return bookEvents;
        }

        public void AddRentalEvent(RentalEvent rentalEvent)
        {
            RentalEvent addedRentalEvent = new RentalEvent
            {
                BooksInLibrary = rentalEvent.BooksInLibrary,
                RentalDate = rentalEvent.RentalDate,
                RentalUser = rentalEvent.RentalUser
            };

            bookEvents.Add(addedRentalEvent);
        }

        public void AddReturnEvent(ReturnEvent returnEvent)
        {
            ReturnEvent addedReturnEvent = new ReturnEvent
            {
                ReturnDate = returnEvent.ReturnDate,
                RentalUser = returnEvent.RentalUser
            };

            bookEvents.Add(addedReturnEvent);
        }
    }
}
