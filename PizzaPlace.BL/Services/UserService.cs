using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public IEnumerable<User> Users => users.Items;

        public UserService(IRepository<User> _users)
        {
            users = _users;
        }

        public User RegisterUser(string name, string surName, string email,
                                             string password, string repeatPassword)
        {
            if (password != repeatPassword) throw new PasswordException("Password not equal repeatPassword");

            var user = new User(name, surName, email, password);

            return users.Add(user);
        }

        public async Task<User> RegisterUserAsync(string name, string surName, string email, string password, string repeatPassword)
        {
             if (password != repeatPassword) throw new PasswordException("Password not equal repeatPassword");

             var user = new User(name, surName, email, password);

             return await users.AddAsync(user).ConfigureAwait(false);
        }
    }
}