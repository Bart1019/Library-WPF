using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public interface IBookEventRepository
    {
        void AddRentalEvent(RentalEvent rentalEvent);
        void AddReturnEvent(ReturnEvent returnEvent);
        IQueryable<BookEvent> GetAllBookReturnEvents();
        IQueryable<BookEvent> GetAllBookRentalEvents();
    }
}