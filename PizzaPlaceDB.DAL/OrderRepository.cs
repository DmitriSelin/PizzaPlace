using Microsoft.EntityFrameworkCore;
using PizzaPlaceDB.DAL.Context;
using PizzaPlaceDB.DAL.Entities;
using System.Linq;

namespace PizzaPlaceDB.DAL
{
    internal class OrderRepository : DbRepository<Order>
    {
        public override IQueryable<Order> Items => base.Items.Include(item => item.Basket);

        public OrderRepository(PizzaPlaceContext dbContext) : base(dbContext) { }
    }
}