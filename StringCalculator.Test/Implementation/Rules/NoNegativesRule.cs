namespace StringCalculator.Test.Implementation.Rules
{
    public class NoNegativesRule : ICalculatorRule
    {
        public int Apply(int input)
        {
            if (input < 0)
            {
                throw new NegativeException(string.Format("negatives not allowed {0}", input));
            }
            return input;
        }
    }
}