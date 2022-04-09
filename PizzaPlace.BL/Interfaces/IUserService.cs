using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    /// <summary>Interface for UserService</summary>
    public interface IUserService
    {
        /// <summary>Log user in system</summary>
        /// <param name="name">User's name</param>
        /// <param name="surName">User's surName</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="repeatPassword">User's repeating password</param>
        /// <returns>New user</returns>
        User RegisterUser(string name, string surName, string email, string password, string repeatPassword);

        /// <summary>Log user in system</summary>
        /// <param name="name">User's name</param>
        /// <param name="surName">User's surName</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="repeatPassword">User's repeating password</param>
        /// <returns>New user</returns>
        Task<User> RegisterUserAsync(string name, string surName, string email, string password, string repeatPassword);

        /// <summary>User's login to the system</summary>
        /// <param name="email">Existing's user email</param>
        /// <param name="password">Existing's user password</param>
        /// <returns>Existing user</returns>
        User SignInApp(string email, string password);

        IEnumerable<User> Users { get; }
    }
}