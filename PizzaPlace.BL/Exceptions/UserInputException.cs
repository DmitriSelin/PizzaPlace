using System;

namespace PizzaPlace.BL.Exceptions
{
    public class UserInputException : Exception
    {
        public UserInputException() { }

        public UserInputException(string message) : base(message) { }
    }
}
