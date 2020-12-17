using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;

namespace Library.Logic
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(int id);
        void EditUser(User user);
        List<User> GetAllUsers();
        User GetUser(int id);
    }
}
