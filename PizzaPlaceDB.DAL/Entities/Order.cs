using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Order : Entity
    {
        public int BasketId { get; set; }

        public virtual Basket Basket { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        public double TotalPrice { get; set; }

        public override string ToString() => $"Order: {Basket} TotalPrice {TotalPrice}";
    }
}
