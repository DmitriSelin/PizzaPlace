using PizzaPlaceDB.DAL.Entities.Base;
using System;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Discount : NamedEntity
    {
        public double Percent { get; set; }

        public Discount(string name, double percent)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Discount's name can not be null", nameof(name));
            }

            if (percent < 0 || percent >= 70)
            {
                throw new ArgumentException("Not correct percent", nameof(percent));
            }

            Name = name;
            Percent = percent;
        }
    }
}
