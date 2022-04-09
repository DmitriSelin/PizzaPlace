using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;

namespace PizzaPlace.BL.Interfaces
{
    /// <summary>Interface for SaleService</summary>
    public interface ISaleService
    {
        /// <summary>Buying food</summary>
        /// <param name="selectedFood">User's selected food</param>
        /// <param name="user">Current user</param>
        /// <returns>Purchased food</returns>
        Food BuyFood(object selectedFood, User user);

        public IEnumerable<Food> Food { get; }

        public IEnumerable<Basket> Baskets { get; }
    }
}
