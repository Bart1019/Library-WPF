using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers().ToList();
        }

        public User GetUser(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public void EditUser(User user)
        {
            userRepository.EditUser(user);
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }
    }
}
