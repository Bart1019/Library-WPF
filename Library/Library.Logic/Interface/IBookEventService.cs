using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;

namespace Library.Logic
{
    public interface IBookEventService
    {
        IEnumerable<BookEvent> GetAllRentals();
        IEnumerable<BookEvent> GetAllReturns();
        RentalEvent RentBook(int userId, int bookId, DateTime rentalDate);
        ReturnEvent ReturnBook(int userId, int bookId, DateTime returnDate);
    }
}
