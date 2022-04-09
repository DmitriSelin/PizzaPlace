using System;

namespace PizzaPlace.BL.Exceptions
{
    /// <summary>User's Exception</summary>
    public class PasswordException : Exception
    {
        public PasswordException() { }

        public PasswordException(string message) : base(message) { }
    }
}
