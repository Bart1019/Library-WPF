using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBookEventRepository
    {
        List<BookEvent> GetAllBookEvents();
        void AddRentalEvent(RentalEvent rentalEvent);
        void AddReturnEvent(ReturnEvent returnEvent);
    }
}
