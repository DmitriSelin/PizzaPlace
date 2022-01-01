using System;

namespace PizzaPlace.WPF.Models
{
    internal class User : Person
    {
        public DateTime BirthDate { get; private set; }

        public string FavoriteFood { get; private set; }

        public int Bonus { get; private set; }

        public User(int id, string login, string password, string firstName, string secondName,
                    DateTime birthDate) : base(id, login, password, firstName, secondName)
        {
            if (birthDate < DateTime.Parse("01.01.1920") || birthDate >= DateTime.Now.Date)
            {
                throw new ArgumentException("Not correct birthDate.", nameof(birthDate));
            }

            BirthDate = birthDate;
            FavoriteFood = "Unknown";
            Bonus = 0;
        }
    }
}