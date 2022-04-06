using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Discount : NamedEntity
    {
        public double Number { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }

        public Discount(string name, double number)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Discount's name can not be null", nameof(name));
            }

            if (number < 0 || number >= 1)
            {
                throw new ArgumentException("Not correct number", nameof(number));
            }

            Name = name;
            Number = number;
        }

        public Discount() { }

        public override string ToString() => $"Discount {Name}";
    }
}