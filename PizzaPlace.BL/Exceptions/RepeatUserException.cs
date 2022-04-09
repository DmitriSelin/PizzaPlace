using System;

namespace PizzaPlace.BL.Exceptions
{
    /// <summary>User's Exception</summary>
    public class RepeatUserException : Exception
    {
        public RepeatUserException() { }

        public RepeatUserException(string message) : base(message) { }
    }
}
