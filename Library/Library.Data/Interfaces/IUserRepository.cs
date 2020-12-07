using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(int id);
        void EditUser(User user);
        IQueryable<User> GetAllUsers();
        User GetUserById(int id);
    }
}