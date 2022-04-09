using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    /// <summary>Interface for BasketService</summary>
    public interface IBasketService
    {
        /// <summary>Add selected food to basket</summary>
        /// <param name="food">User's selected food</param>
        /// <param name="user">Current user</param>
        /// <returns>new entry in the basket table</returns>
        Basket PutFoodToBasket(object food, User user);

        /// <summary>Add selected food to basket</summary>
        /// <param name="food">User's selected food</param>
        /// <param name="user">Current user</param>
        /// <returns>new entry in the basket table</returns>
        Task<Basket> PutFoodToBasketAsync(object food, User user);

        IEnumerable<Food> Food { get; }

        IEnumerable<Basket> Baskets { get; }
    }
}
