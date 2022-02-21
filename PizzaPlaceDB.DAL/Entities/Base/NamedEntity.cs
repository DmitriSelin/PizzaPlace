using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceDB.DAL.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}