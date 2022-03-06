using Microsoft.EntityFrameworkCore;
using PizzaPlaceDB.DAL.Context;
using PizzaPlaceDB.DAL.Entities;
using System.Linq;

namespace PizzaPlaceDB.DAL
{
    internal class BasketRepository : DbRepository<Basket>
    {
        public override IQueryable<Basket> Items => base.Items
            .Include(item => item.User)
            .Include(item => item.Food)
            .Include(item => item.Discount);

        public BasketRepository(PizzaPlaceContext dbContext) : base(dbContext) { }
    }
}
