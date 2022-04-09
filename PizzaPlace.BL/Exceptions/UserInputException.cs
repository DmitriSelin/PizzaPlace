using System;

namespace PizzaPlace.BL.Exceptions
{
    /// <summary>User's Exception</summary>
    public class UserInputException : Exception
    {
        public UserInputException() { }

        public UserInputException(string message) : base(message) { }
    }
}
