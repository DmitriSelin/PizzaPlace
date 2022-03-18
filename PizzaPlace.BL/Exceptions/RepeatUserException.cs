using System;

namespace PizzaPlace.BL.Exceptions
{
    public class RepeatUserException : Exception
    {
        public RepeatUserException() { }

        public RepeatUserException(string message) : base(message) { }
    }
}
