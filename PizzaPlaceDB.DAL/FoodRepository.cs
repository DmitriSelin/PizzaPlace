using Microsoft.EntityFrameworkCore;
using PizzaPlaceDB.DAL.Context;
using PizzaPlaceDB.DAL.Entities;
using System.Linq;

namespace PizzaPlaceDB.DAL
{
    internal class FoodRepository : DbRepository<Food>
    {
        public override IQueryable<Food> Items => base.Items
            .Include(item => item.Category)
            .Include(item => item.Admin);


        public FoodRepository(PizzaPlaceContext dbContext) : base(dbContext) { }
    }
}
