using PizzaPlaceDB.DAL.Entities.Base;
using System;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Order : Entity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int BasketId { get; set; }

        public virtual Basket Basket { get; set; }

        public DateTime PurchaseDate { get; set; }

        public double TotalPrice { get; set; }
    }
}
