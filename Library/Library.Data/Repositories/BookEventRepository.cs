using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class BookEventRepository : IBookEventRepository
    {
        private readonly DataContext _dataContext;

        public BookEventRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<BookEvent> GetAllBookEvents()
        {
            return _dataContext.BookEvents;
        }

        public void AddRentalEvent(RentalEvent rentalEvent)
        {
            var addedRentalEvent = new RentalEvent
            {
                BookInLibrary = rentalEvent.BookInLibrary,
                RentalDate = rentalEvent.RentalDate,
                RentalUser = rentalEvent.RentalUser
            };

            _dataContext.BookEvents.Add(addedRentalEvent);
        }

        public void AddReturnEvent(ReturnEvent returnEvent)
        {
            var addedReturnEvent = new ReturnEvent
            {
                ReturnDate = returnEvent.ReturnDate,
                RentalUser = returnEvent.RentalUser
            };

            _dataContext.BookEvents.Add(addedReturnEvent);
        }
    }
}