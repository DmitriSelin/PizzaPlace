using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlace.BL.Services
{
    /// <summary>Service for buying food</summary>
    public class SaleService : ISaleService
    {
        private readonly IRepository<Food> food;

        private readonly IRepository<Basket> baskets;

        public IEnumerable<Food> Food => food.Items;

        public IEnumerable<Basket> Baskets => baskets.Items;

        public SaleService(IRepository<Food> _food, IRepository<Basket> _baskets)
        {
            food = _food;
            baskets = _baskets;
        }

        /// <summary>Buying food</summary>
        /// <param name="_selectedFood">User's selected food</param>
        /// <param name="user">Current user</param>
        /// <returns>Purchased food</returns>
        public Food BuyFood(object _selectedFood, User user)
        {
            if (_selectedFood == null) 
                throw new UserInputException("User didn't select the food");

            Food selectedFood = (Food)_selectedFood;

            Basket basket = baskets.Items
                .FirstOrDefault(x => x.FoodId == selectedFood.Id && x.UserId == user.Id);

            baskets.Remove(basket.Id);
            food.Remove(selectedFood.Id);

            return selectedFood;
        }
    }
}