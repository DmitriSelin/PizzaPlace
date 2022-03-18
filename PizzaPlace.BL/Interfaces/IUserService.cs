using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    public interface IUserService
    {
        User RegisterUser(string name, string surName, string email, string password, string repeatPassword);

        Task<User> RegisterUserAsync(string name, string surName, string email, string password, string repeatPassword);

        User SignInApp(string email, string password);

        IEnumerable<User> Users { get; }
    }
}
