using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    public interface IBasketService
    {
        Basket PutFoodToBasket(object food, User user);

        Task<Basket> PutFoodToBasketAsync(object food, User user);

        IEnumerable<Food> Food { get; }

        IEnumerable<Basket> Baskets { get; }
    }
}
