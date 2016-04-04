using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Test.Parser
{
    public class CalculationStringParser : IStringParser
    {
        private Tuple<List<string>,string> SeperateAndObtainDelimiters(string unparsedCalculationString)
        {
            var splitters = new List<string> { ",", "\n" };
            if (unparsedCalculationString.StartsWith("//"))
            {
                var newDelimiterSet = unparsedCalculationString.Substring(2, unparsedCalculationString.IndexOf("\n", StringComparison.Ordinal) - 2);

                var delimiterSplitters = new List<string> { "]", "[" };

                var userDefinedDelimiters = newDelimiterSet.Split(delimiterSplitters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                splitters.AddRange(userDefinedDelimiters);

                unparsedCalculationString = unparsedCalculationString.Substring(unparsedCalculationString.IndexOf("\n", StringComparison.Ordinal));
            }

            return new Tuple<List<string>, string>(splitters,unparsedCalculationString);
        }

        public List<string> Parse(string input)
        {
            var answer = SeperateAndObtainDelimiters(input);
            var splitters = answer.Item1;
            var cleanString = answer.Item2;
            return cleanString.Split(splitters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}