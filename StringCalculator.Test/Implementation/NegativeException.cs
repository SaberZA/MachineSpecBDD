using System;

namespace StringCalculator.Test
{
    public class NegativeException: Exception
    {
        public NegativeException(string message) : base(message)
        {
                   
        }
    }
}