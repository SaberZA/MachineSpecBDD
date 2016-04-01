using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Test
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var splitters = new List<string> { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                var newDelimiterSet = numbers.Substring(2, numbers.IndexOf("\n", System.StringComparison.Ordinal) - 2);

                var delimiterSplitters = new List<string>() {"]", "["};

                var userDefinedDelimiters = newDelimiterSet.Split(delimiterSplitters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                splitters.AddRange(userDefinedDelimiters);

                numbers = numbers.Substring(numbers.IndexOf("\n", System.StringComparison.Ordinal));
            }
            
            var negatives = new List<string>();
            var sum = numbers.Split(splitters.ToArray(),StringSplitOptions.RemoveEmptyEntries).ToList().Sum(p =>
            {
                var i = Int32.Parse(p);
                if (i < 0)
                {
                    negatives.Add(i.ToString());
                }

                if (i > 1000)
                {
                    i = 0;
                }

                return i;
            });

            if (negatives.Any())
            {
                var negativesString = string.Join(",", negatives);
                throw new NegativeException(string.Format("negatives not allowed {0}",negativesString));
            }

            return sum;
        }
    }
}