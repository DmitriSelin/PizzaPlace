using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Discount : NamedEntity
    {
        public double Percent { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }

        public Discount(string name, double percent)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Discount's name can not be null", nameof(name));
            }

            if (percent < 0 || percent >= 1)
            {
                throw new ArgumentException("Not correct percent", nameof(percent));
            }

            Name = name;
            Percent = percent;
        }

        public Discount() { }
    }
}
