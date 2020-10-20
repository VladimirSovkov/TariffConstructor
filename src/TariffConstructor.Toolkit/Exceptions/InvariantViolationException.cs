using System;

namespace TariffConstructor.Toolkit.Exceptions
{
    public class InvariantViolationException : Exception
    {
        public InvariantViolationException(string message)
            : base(message)
        { 
        }

        public InvariantViolationException(string message, string code)
    : base(message + ". Code: " + code)
        {
        }
    }
}
