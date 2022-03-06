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

        public async Task<User> RegisterUser(string name, string surName, string email,
                                             string password, string repeatPassword)
        {
            if (repeatPassword != password) throw new PasswordException("Password not equal repeatPassword");

            try
            {
                var user = new User(name, surName, email, password);

                return await users.AddAsync(user).ConfigureAwait(false);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
