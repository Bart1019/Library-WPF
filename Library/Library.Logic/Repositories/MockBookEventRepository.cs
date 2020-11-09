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
                new BookEvent { Id = 1, RentalDate = default, GiveBackDate = default, EventType = default, RentalUser = default, BooksInLibrary = default },
                new BookEvent { Id = 2, RentalDate = default, GiveBackDate = default, EventType = default, RentalUser = default, BooksInLibrary = default },
                new BookEvent { Id = 3, RentalDate = default, GiveBackDate = default, EventType = default, RentalUser = default, BooksInLibrary = default }
            };
        }

        public List<BookEvent> GetAllBookEvents()
        {
            return bookEvents;
        }

        public BookEvent GetBookEventById(int id)
        {
            return bookEvents.FirstOrDefault(i => i.Id.Equals(id));
        }

        public void DeleteBookEvent(int id)
        {
            BookEvent deletedBookEvent = bookEvents.FirstOrDefault(i => i.Id.Equals(id));

            if(deletedBookEvent != null)
            {
                bookEvents.Remove(deletedBookEvent);
            }
        }

        public void EditBookEvent(BookEvent bookEvent)
        {
            BookEvent editedBookEvent = bookEvents.FirstOrDefault(r => r.Id.Equals(bookEvent.Id));

            if (editedBookEvent != null)
            {
                editedBookEvent.RentalDate = bookEvent.RentalDate;
                editedBookEvent.GiveBackDate = bookEvent.GiveBackDate;
                editedBookEvent.EventType = bookEvent.EventType;
                editedBookEvent.RentalUser = bookEvent.RentalUser;
                editedBookEvent.BooksInLibrary = bookEvent.BooksInLibrary;
            }
        }

        public void AddBookEvent(BookEvent bookEvent)
        {
            BookEvent addedBookEvent = new BookEvent
            {
                Id = bookEvent.Id,
                RentalDate = bookEvent.RentalDate,
                GiveBackDate = bookEvent.GiveBackDate,
                EventType = bookEvent.EventType,
                RentalUser = bookEvent.RentalUser,
                BooksInLibrary = bookEvent.BooksInLibrary
            };

            bookEvents.Add(addedBookEvent);
        }
    }
}
