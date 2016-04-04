using System;
using Machine.Specifications;

namespace StringCalculator.Test.Tests
{
    [Subject("Calculator")]
    public class When_adding_an_empty_string : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("");
        It should_equal_zero = () => _answer.ShouldEqual(0);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1 : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("1");
        It should_equal_1 = () => _answer.ShouldEqual(1);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_and_2 : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("1,2");
        It should_equal_3 = () => _answer.ShouldEqual(3);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_2_and_3 : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("1,2,3");
        It should_equal_6 = () => _answer.ShouldEqual(6);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_and_2_separated_by_newline : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("1\n2,3");
        It should_equal_6 = () => _answer.ShouldEqual(6);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_and_2_separated_by_newline_and_comma : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("1\n2,3");
        It should_equal_6 = () => _answer.ShouldEqual(6);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_given_custom_delimiter : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("//;\n1;2");
        It should_equal_3 = () => _answer.ShouldEqual(3);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_negative_1_and_positive_2 : CalculatorTestContext
    {
        Because of = () => _exception = Catch.Exception(() => Calculator.Add("-1,2"));

        It should_throw_exception_of_type_negative_exception = () => _exception.ShouldBeOfExactType<NegativeException>();
        It should_throw_exception_with_message = () => _exception.Message.ShouldContain("negatives not allowed");

        private static int _answer;
        private static Exception _exception;
    }

    [Subject("Calculator")]
    public class When_adding_1001_and_2 : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("1001,2");
        It should_equal_2 = () => _answer.ShouldEqual(2);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_given_a_custom_delimter_of_any_length : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("//[***]\n1***2***3");
        It should_equal_6 = () => _answer.ShouldEqual(6);
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_given_multiple_custom_delimiters : CalculatorTestContext
    {
        Because of = () => _answer = Calculator.Add("//[**][%]\n1%2**3");
        It should_equal_6 = () => _answer.ShouldEqual(6);
        private static int _answer;
    }
}
