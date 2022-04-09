using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Services
{
    /// <summary>Service for adding food to basket</summary>
    public class BasketService : IBasketService
    {
        private readonly IRepository<Food> food;
        private readonly IRepository<Basket> baskets;

        public IEnumerable<Food> Food => food.Items;

        public IEnumerable<Basket> Baskets => baskets.Items;

        public BasketService(IRepository<Food> _food, IRepository<Basket> _baskets)
        {
            food = _food;
            baskets = _baskets;
        }

        /// <summary>Add selected food to basket</summary>
        /// <param name="food">User's selected food</param>
        /// <param name="user">Current user</param>
        /// <returns>new entry in the basket table</returns>
        public Basket PutFoodToBasket(object food, User user)
        {
            if (food == null)
            {
                throw new UserInputException("Food not select");
            }

            Food currentFood = (Food)food;

            Basket repeatBasket = baskets.Items.SingleOrDefault(x => x.UserId == user.Id && x.FoodId == currentFood.Id);

            if (repeatBasket != null)
            {
                throw new RepeatUserException("User has already added this food to the cart");
            }

            var basket = new Basket
            {
                UserId = user.Id,
                FoodId = currentFood.Id,
                DiscountId = 1
            };

            return baskets.Add(basket);
        }

        /// <summary>Add selected food to basket</summary>
        /// <param name="food">User's selected food</param>
        /// <param name="user">Current user</param>
        /// <returns>new entry in the basket table</returns>
        public async Task<Basket> PutFoodToBasketAsync(object food, User user)
        {
            if (food == null)
            {
                throw new UserInputException("Food not select");
            }

            Food currentFood = (Food)food;

            Basket repeatBasket = baskets.Items.SingleOrDefault(x => x.UserId == user.Id && x.FoodId == currentFood.Id);

            if (repeatBasket != null)
            {
                throw new RepeatUserException("User has already added this food to the cart");
            }

            var basket = new Basket
            {
                UserId = user.Id,
                FoodId = currentFood.Id,
                DiscountId = 1
            };

            return await baskets.AddAsync(basket);
        }
    }
}
