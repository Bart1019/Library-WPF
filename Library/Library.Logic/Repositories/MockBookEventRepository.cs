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
                new ReturnEvent { ReturnDate = default, RentalUser = default, BooksInLibrary = default },
            };
        }

        public List<BookEvent> GetAllBookEvents()
        {
            return bookEvents;
        }
    }
}
