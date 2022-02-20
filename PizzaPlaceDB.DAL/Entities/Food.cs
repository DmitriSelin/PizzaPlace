using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Food : NamedEntity
    {
        public double Price { get; set; }

        public string Description { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int ExpirationDate { get; set; }

        public ICollection<Basket> Baskets { get; set; }

        public int AdminId { get; set; }

        public virtual Admin Admin { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Food(string name, double price, string description, int expirationDate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Food's name can not be null", nameof(name));
            }

            if (price <= 0 || price > double.MaxValue)
            {
                throw new ArgumentException("Not correct price", nameof(price));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("Description can not be null", nameof(description));
            }

            if (expirationDate < 0 || expirationDate > 5)
            {
                throw new ArgumentException("Not correct expirationDate", nameof(expirationDate));
            }

            Name = name;
            Price = price;
            Description = description;
            ManufactureDate = DateTime.Now.Date;
            ExpirationDate = expirationDate;
        }

        public Food() { }
    }
}