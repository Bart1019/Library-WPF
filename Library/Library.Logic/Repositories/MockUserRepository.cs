using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>
            {
                new User{Id = 1, Name = "Bartek", Surname = "Runowski", AmountOfBooksRented = 1},
                new User{Id = 2, Name = "Wojtek", Surname = "Wozniak", AmountOfBooksRented = 4},
                new User{Id = 3, Name = "Mati", Surname = "Stolar", AmountOfBooksRented = 0},
            };
        }

        public IQueryable<User> GetAll()
        {
            return _users.AsQueryable();
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(i => i.Id.Equals(id));
        }

        public void Delete(int id)
        {
            User deletedUser = _users.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedUser != null)
            {
                _users.Remove(deletedUser);
            }
        }

        public void Edit(User user)
        {
            User editedUser = _users.FirstOrDefault(b => b.Id.Equals(user.Id));

            if (editedUser != null)
            {
                editedUser.Id = user.Id;
                editedUser.Name = user.Name;
                editedUser.Surname = user.Surname;
                editedUser.AmountOfBooksRented = user.AmountOfBooksRented;
            }
        }

        public void Add(User user)
        {
            User addedUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                AmountOfBooksRented = user.AmountOfBooksRented
            };

            _users.Add(addedUser);
        }
    }
}
