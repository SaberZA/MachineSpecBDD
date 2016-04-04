using System.Collections.Generic;
using StringCalculator.Test.Implementation;
using StringCalculator.Test.Implementation.Rules;
using StringCalculator.Test.Parser;
using StructureMap;

namespace StringCalculator.Test.Tests
{
    public class CalculatorTestContext
    {
        protected static Calculator Calculator;

        public CalculatorTestContext()
        {
            var container = new Container(_ =>
            {
                _.For<IStringParser>().Use<CalculationStringParser>();
                
            });

            var rules = new List<ICalculatorRule>()
            {
                new NumbersMoreThanAThousandAreZero(),
                new NoNegativesRule()
            };
            Calculator = new Calculator(container.GetInstance<IStringParser>(),rules);
        }
    }
}