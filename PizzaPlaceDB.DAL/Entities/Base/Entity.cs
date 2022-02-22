using PizzaPlace.BL.Interfaces;

namespace PizzaPlaceDB.DAL.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}