﻿using PizzaPlace.BL.Exceptions;
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

        public IEnumerable<Food> Food => food.Items;

        public IEnumerable<Basket> Baskets => baskets.Items;

        public BasketService(IRepository<Food> _food, IRepository<Basket> _baskets)
        {
            food = _food;
            baskets = _baskets;
        }

        public Basket PutFoodToBasket(object food, User user)
        {
            if (food == null)
            {
                throw new UserInputException("Food not select");
            }

            Food currentFood = (Food)food;

            var basket = new Basket
            {
                UserId = user.Id,
                FoodId = currentFood.Id
            };

            return baskets.Add(basket);
        }

        public async Task<Basket> PutFoodToBasketAsync(object food, User user)
        {
            if (food == null)
            {
                throw new UserInputException("Food not select");
            }

            Food currentFood = (Food)food;

            var basket = new Basket
            {
                UserId = user.Id,
                FoodId = currentFood.Id
            };

            return await baskets.AddAsync(basket);
        }
    }
}