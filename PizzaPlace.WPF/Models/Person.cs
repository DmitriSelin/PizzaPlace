using System;

namespace PizzaPlace.WPF.Models
{
    internal class Person
    {
        public int Id { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public Person(int id, string login, string password, string firstName, string secondName)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Not correct id", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException("login can not be null.", nameof(login));
            }
            else if (login.Length < 2)
            {
                throw new ArgumentException("login's length can not be < 2", nameof(login));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password can not be null.", nameof(password));
            }
            else if (password.Length < 8)
            {
                throw new ArgumentException("password's length can not be < 8", nameof(password));
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("firstName can not be null.", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(secondName))
            {
                throw new ArgumentNullException("secondName can not be null.", nameof(secondName));
            }

            Id = id;
            Login = login;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
        }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}";
        }
    }
}