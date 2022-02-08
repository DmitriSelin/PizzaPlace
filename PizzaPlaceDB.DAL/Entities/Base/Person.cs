namespace PizzaPlaceDB.DAL.Entities.Base
{
    public abstract class Person : NamedEntity
    {
        public string SurName { get; set; }
    }
}
