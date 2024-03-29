﻿using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace PizzaPlaceDB.DAL.Entities
{
    public class User : Person
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FavoriteFood { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }

        public int BonusId { get; set; }

        public virtual Bonus Bonus { get; set; }

        public User(string name, string surName, string email, string password)
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
                throw new ArgumentNullException("Email can not be null", nameof(email));
            }
            else if (email.Length < 1 || email.Length > 50 || !email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("Not correct email", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Password can not be null", nameof(password));
            }
            else if (password.Length < 6 || password.Length > 50)
            {
                throw new ArgumentException("Not correct password", nameof(password));
            }

            Name = name;
            SurName = surName;
            Email = email;
            Password = password;
        }

        public User() { }

        public override string ToString() => $"User {Name} {SurName}";
    }
}
