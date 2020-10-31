using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface ILibraryRepository
    {
        IQueryable<Book> GetAllAvailableBooks();
        IQueryable<Book> GetAllUnAvailableBooks();s
    }
}
