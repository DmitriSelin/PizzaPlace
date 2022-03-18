using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class Admin : Person
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public int Rating { get; set; }

        public virtual ICollection<Food> Food { get; set; }

        public Admin(string name, string surName, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be null", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(surName))
            {
                throw new ArgumentNullException("SurName can not be null", nameof(surName));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email con not be null", nameof(email));
            }
            else if (email.Length < 1 || email.Length > 50 || !email.Contains("@") || !email.Contains("."))
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

            Name = name;
            SurName = surName;
            Email = email;
            Password = password;
            Rating = 0;
        }

        public Admin() { }

        public override string ToString() => $"Admin {Name} {SurName}";
    }
}
