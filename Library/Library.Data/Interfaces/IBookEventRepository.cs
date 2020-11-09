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
        BookEvent GetBookEventById(int id);
        void DeleteBookEvent(int id);
        void EditBookEvent(BookEvent bookEvent);
        void AddBookEvent(BookEvent bookEvent);
    }
}
