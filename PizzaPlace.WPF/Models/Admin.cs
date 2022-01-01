namespace PizzaPlace.WPF.Models
{
    internal class Admin : Person
    {
        public int Rating { get; private set; }

        public Admin(int id, string login, string password, string firstName,
                    string secondName) : base(id, login, password, firstName, secondName)
        {
            Rating = 1;
        }
    }
}