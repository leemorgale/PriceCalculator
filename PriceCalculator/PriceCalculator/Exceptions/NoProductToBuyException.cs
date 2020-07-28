using System;

namespace PriceCalculator.App.Exceptions
{
    public class NoProductToBuyException : Exception
    {
        public NoProductToBuyException()
        {
        }

        public NoProductToBuyException(string message) : base(message)
        {
        }

        public NoProductToBuyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
