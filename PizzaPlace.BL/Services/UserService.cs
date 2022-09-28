using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PizzaPlace.BL.Services
{
    /// <summary>Service for logging or signing users</summary>
    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public IEnumerable<User> Users => users.Items;

        public UserService(IRepository<User> _users)
        {
            users = _users;
        }

        /// <summary>Log user in system</summary>
        /// <param name="name">User's name</param>
        /// <param name="surName">User's surName</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="repeatPassword">User's repeating password</param>
        /// <returns>New user</returns>
        public User RegisterUser(string name, string surName, string email,
                                             string password, string repeatPassword)
        {
            if (password != repeatPassword)
                throw new PasswordException("Password not equal repeatPassword");

            User repeatUser = users.Items.SingleOrDefault(x => x.Email == email);

            if (repeatUser != null)
                throw new RepeatUserException("DataBase has the same user");

            var user = new User(name, surName, email, password)
            {
                BonusId = 1
            };

            return users.Add(user);
        }

        /// <summary>Log user in system</summary>
        /// <param name="name">User's name</param>
        /// <param name="surName">User's surName</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="repeatPassword">User's repeating password</param>
        /// <returns>New user</returns>
        public async Task<User> RegisterUserAsync(string name, string surName, string email, string password, string repeatPassword)
        {
            if (password != repeatPassword) 
                throw new PasswordException("Password not equal repeatPassword");

            User repeatUser = users.Items.SingleOrDefault(x => x.Email == email);

            if (repeatUser != null)
                throw new RepeatUserException("DataBase has the same user");

            var user = new User(name, surName, email, password)
            { 
                BonusId = 1
            };

            return await users.AddAsync(user).ConfigureAwait(false);
        }

        /// <summary>User's login to the system</summary>
        /// <param name="email">Existing's user email</param>
        /// <param name="password">Existing's user password</param>
        /// <returns>Existing user</returns>
        public User SignInApp(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email can not be null", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Password can not be null", nameof(password));
            }

            User enterUser = users.Items.SingleOrDefault(x => x.Email == email && x.Password == password);

            if (enterUser == null)
            {
                throw new UserInputException("Not found user with these email and password");
            }

            return enterUser;
        }
    }
}