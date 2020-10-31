using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetById(int id);
        void Delete(int id);
        void Edit(User user);
        void Add(User user);
    }
}
