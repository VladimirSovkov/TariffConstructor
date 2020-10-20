using System;

namespace TariffConstructor.Toolkit.Exceptions
{
    public class InvariantViolationException : Exception
    {
        public InvariantViolationException(string message)
            : base(message)
        { 
        }
    }
}
