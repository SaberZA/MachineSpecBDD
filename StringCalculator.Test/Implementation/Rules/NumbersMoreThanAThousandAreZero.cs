namespace StringCalculator.Test.Implementation.Rules
{
    public class NumbersMoreThanAThousandAreZero : ICalculatorRule
    {
        public int Apply(int input)
        {
            if (input > 1000)
            {
                input = 0;
            }
            return input;
        }
    }
}