using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBooksStateRepository
    {
        BooksCatalog GetAllAvailableBooks();
        void UpdateBooksAmount(int bookId, int actualBookAmount);
    }
}
