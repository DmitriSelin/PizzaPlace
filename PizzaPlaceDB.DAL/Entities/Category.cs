using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Category : NamedEntity
    {
        public virtual ICollection<Food> Food { get; set; }

        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Category's name can not be null", nameof(name));
            }

            Name = name;
        }

        public Category() { }

        public override string ToString() => $"Category {Name}";
    }
}
