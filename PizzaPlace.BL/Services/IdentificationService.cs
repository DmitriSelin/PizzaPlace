using PizzaPlaceDB.DAL;
using PizzaPlaceDB.DAL.Context;
using PizzaPlaceDB.DAL.Entities;

namespace PizzaPlace.BL.Services
{
    public class IdentificationService
    {
        public DbRepository<User> DbRepository { get; set; }

        public IdentificationService(PizzaPlaceContext context)
        {
            DbRepository = new DbRepository<User>(context);
        }
    }
}
