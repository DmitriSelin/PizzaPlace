using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    public interface IBasketService
    {
        Basket PutFoodToBasket(object food);

        Task<Basket> PutFoodToBasketAsync(object food);

        IEnumerable<Food> Food { get; }

        IEnumerable<Basket> Baskets { get; }
    }
}
