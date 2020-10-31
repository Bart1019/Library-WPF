using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        Book GetById(int id);
        Book GetByType(BookEnum bookType);
        void Delete(int id);
        void Edit(Book book);
        void Add(Book book);
    }
}
