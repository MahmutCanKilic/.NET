using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Repos
{
    public class UserRepository
    {
        public List<User> Users { get; set; }

        
        public UserRepository()
        {
            Users = new List<User>();
        }

        public void Add(User user)
        {
            Users.Add(user);
        }

        public bool Exist(User user)
        {
            User existingUser = Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            return existingUser != null;
        }

        public List<User> GetAll()
        {
            return Users;
        }
    }
}
