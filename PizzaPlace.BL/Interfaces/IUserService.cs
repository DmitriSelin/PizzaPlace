using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUser(string name, string surName, string email, string password, string repeatPassword);

        IEnumerable<User> Users { get; }
    }
}
