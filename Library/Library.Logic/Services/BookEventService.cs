﻿using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.Logic
{
    public class BookEventService
    {
        private readonly LibraryDbContext _dbContext;

        public BookEventService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRentalEvent(RentalEvent rentalEvent)
        {
            var addedRentalEvent = new RentalEvent
            {
                BookInLibrary = rentalEvent.BookInLibrary,
                EventDate = rentalEvent.EventDate,
                RentalUser = rentalEvent.RentalUser
            };

            _dbContext.RentalEvents.Add(addedRentalEvent);

            _dbContext.SaveChanges();
        }

        public void AddReturnEvent(ReturnEvent returnEvent)
        {
            var addedReturnEvent = new ReturnEvent
            {
                EventDate = returnEvent.EventDate,
                RentalUser = returnEvent.RentalUser
            };

            _dbContext.ReturnEvents.Add(addedReturnEvent);

            _dbContext.SaveChanges();
        }

        public IEnumerable<BookEvent> GetAllBookReturnEvents()
        {
            return _dbContext.ReturnEvents;
        }

        public IEnumerable<BookEvent> GetAllBookRentalEvents()
        {
            return _dbContext.RentalEvents;
        }
    }
}