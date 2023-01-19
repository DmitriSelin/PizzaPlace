using Microsoft.EntityFrameworkCore;
using PizzaPlaceDB.DAL.Context;
using PizzaPlaceDB.DAL.Entities;
using System.Linq;

namespace PizzaPlaceDB.DAL
{
    internal class FoodRepository : DbRepository<Food>
    {
        public override IQueryable<Food> Items => base.Items
            .Include(item => item.Category);


        public FoodRepository(PizzaPlaceContext dbContext) : base(dbContext) { }
    }
}