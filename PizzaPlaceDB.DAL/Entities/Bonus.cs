using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Bonus : NamedEntity
    {
        public double Discount { get; set; }

        public ICollection<User> Users { get; set; }

        public Bonus(string name, double discount)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be null", nameof(name));
            }

            if (discount < 0 || discount > 0.75)
            {
                throw new ArgumentException("Discount can not be null");
            }

            Name = name;
            Discount = discount;
        }

        public Bonus() {}
    }
}
