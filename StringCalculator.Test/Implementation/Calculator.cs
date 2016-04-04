using System;
using System.Collections.Generic;
using System.Linq;
using StringCalculator.Test.Implementation.Rules;
using StringCalculator.Test.Parser;

namespace StringCalculator.Test.Implementation
{
    public class Calculator
    {
        private readonly IStringParser _stringParser;
        private readonly List<ICalculatorRule> _rules;

        public Calculator(IStringParser stringParser, List<ICalculatorRule> rules)
        {
            _stringParser = stringParser;
            _rules = rules;
        }

        public int Add(string numbers)
        {
            var sum = _stringParser.Parse(numbers).Sum(p =>
            {
                var i = Int32.Parse(p);
                _rules.ForEach(rule =>
                {
                    i = rule.Apply(i);
                });
                return i;
            });

            return sum;
        }
    }
}