using System.Collections.Generic;

namespace StringCalculator.Test.Parser
{
    public interface IStringParser
    {
        List<string> Parse(string input);
    }
}