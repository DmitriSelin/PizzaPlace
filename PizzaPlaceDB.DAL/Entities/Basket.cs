using PizzaPlaceDB.DAL.Entities.Base;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Basket : Entity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        public int DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString() => $"Basket: {User} : {Food} : {Discount}";
    }
}
