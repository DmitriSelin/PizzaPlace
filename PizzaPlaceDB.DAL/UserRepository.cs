using Microsoft.EntityFrameworkCore;
using PizzaPlaceDB.DAL.Context;
using PizzaPlaceDB.DAL.Entities;
using System.Linq;

namespace PizzaPlaceDB.DAL
{
    internal class UserRepository : DbRepository<User>
    {
        public override IQueryable<User> Items => base.Items.Include(item => item.Bonus);

        public UserRepository(PizzaPlaceContext dbContext) : base(dbContext) { }
    }
}
