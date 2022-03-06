using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Services
{
    public class UserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> _users)
        {
            users = _users;
        }

        public async Task<User> RegisterUser(string name, string surName, string email,
                                             string password, string repeatPassword)
        {
            if (repeatPassword != password) throw new 
        }
    }
}
