﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> users;

        public MockUserRepository()
        {
            users = new List<User>
            {
                new User{Id = 1, Name = "Bartek", Surname = "Runowski", AmountOfBooksRented = 1},
                new User{Id = 2, Name = "Wojtek", Surname = "Wozniak", AmountOfBooksRented = 4},
                new User{Id = 3, Name = "Mati", Surname = "Stolar", AmountOfBooksRented = 0},
            };
        }

        public IQueryable<User> GetAllUsers()
        {
            return users.AsQueryable();
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(i => i.Id.Equals(id));
        }

        public void DeleteUser(int id)
        {
            User deletedUser = users.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedUser != null)
            {
                users.Remove(deletedUser);
            }
        }

        public void EditUser(User user)
        {
            User editedUser = users.FirstOrDefault(b => b.Id.Equals(user.Id));

            if (editedUser != null)
            {
                editedUser.Id = user.Id;
                editedUser.Name = user.Name;
                editedUser.Surname = user.Surname;
                editedUser.AmountOfBooksRented = user.AmountOfBooksRented;
            }
        }

        public void AddUser(User user)
        {
            User addedUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                AmountOfBooksRented = user.AmountOfBooksRented
            };

            users.Add(addedUser);
        }
    }
}
