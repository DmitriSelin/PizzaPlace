using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Food> food;
        private readonly IRepository<Basket> baskets;
        private readonly User user;

        public IEnumerable<Food> Food => food.Items;

        public IEnumerable<Basket> Baskets => baskets.Items;

        public BasketService(IRepository<Food> _food, IRepository<Basket> _baskets, User _user)
        {
            food = _food;
            baskets = _baskets;
            user = _user;
        }

        public Basket PutFoodToBasket(object food)
        {
            if (food == null)
            {
                throw new UserInputException("Food not select");
            }

            Food currentFood = (Food)food;
            User currentUser = user;

            var basket = new Basket
            {
                UserId = currentUser.Id,
                FoodId = currentFood.Id
            };

            return baskets.Add(basket);
        }

        public async Task<Basket> PutFoodToBasketAsync(object food)
        {
            if (food == null)
            {
                throw new UserInputException("Food not select");
            }

            Food currentFood = (Food)food;
            User currentUser = user;

            var basket = new Basket
            {
                UserId = currentUser.Id,
                FoodId = currentFood.Id
            };

            return await baskets.AddAsync(basket);
        }
    }
}
