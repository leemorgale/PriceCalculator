using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.App.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message)
        {
            
        }
    }
}
