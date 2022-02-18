using PizzaPlaceDB.DAL.Entities.Base;
using System;

namespace PizzaPlaceDB.DAL.Entities
{
    public class User : Person
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public string FavoriteFood { get; set; }

        public int Bonus { get; set; }

        public User(string name, string surName, string email, string password, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name con not be null", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(surName))
            {
                throw new ArgumentNullException("SurName con not be null", nameof(surName));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email con not be null", nameof(email));
            }
            else if (email.Length < 1 || email.Length > 50)
            {
                throw new ArgumentException("Not correct email", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Password con not be null", nameof(password));
            }
            else if (password.Length < 8 || password.Length > 50)
            {
                throw new ArgumentException("Not correct password", nameof(password));
            }

            if (birthDate <= DateTime.Parse("01.01.1920") || birthDate >= DateTime.Now.Date)
            {
                throw new ArgumentException("Not correct birthDate", nameof(birthDate));
            }

            Name = name;
            SurName = surName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            FavoriteFood = "UnKnown";
            Bonus = 0;
        }
    }
}
