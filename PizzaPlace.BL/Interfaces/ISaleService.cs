using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;

namespace PizzaPlace.BL.Interfaces
{
    public interface ISaleService
    {
        Food BuyFood(object selectedFood, User user);

        public IEnumerable<Food> Food { get; }

        public IEnumerable<Basket> Baskets { get; }
    }
}
