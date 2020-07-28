using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.App.Exceptions
{
    public class NoProductToBuyException : Exception
    {
        public NoProductToBuyException(string message)
            : base(message)
        {
            
        }
    }
}
