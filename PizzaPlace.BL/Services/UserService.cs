using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

            var user = new User
            {
                Email = email,
                Password = password
            };

            User enterUser = users.Items.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (enterUser == null)
            {
                throw new UserInputException("Not found user with these email and password");
            }

            return enterUser;
        }
    }
}