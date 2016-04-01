using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Test
{
    [Subject("Calculator")]
    public class When_adding_an_empty_string
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("");

        It should_equal_zero = () => _answer.ShouldEqual(0);
        
        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("1");

        It should_equal_1 = () => _answer.ShouldEqual(1);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_and_2
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("1,2");

        It should_equal_3 = () => _answer.ShouldEqual(3);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_2_and_3
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("1,2,3");

        It should_equal_6 = () => _answer.ShouldEqual(6);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_and_2_separated_by_newline
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("1\n2,3");

        It should_equal_6 = () => _answer.ShouldEqual(6);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_1_and_2_separated_by_newline_and_comma
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("1\n2,3");

        It should_equal_6 = () => _answer.ShouldEqual(6);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_given_custom_delimiter
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };
        
        Because of = () => _answer = _calculator.Add("//;\n1;2");

        It should_equal_3 = () => _answer.ShouldEqual(3);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_adding_negative_1_and_positive_2
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _exception = Catch.Exception(() => _calculator.Add("-1,2"));

        It should_throw_exception_of_type_negative_exception = () => _exception.ShouldBeOfExactType<NegativeException>();
        It should_throw_exception_with_message = () => _exception.Message.ShouldContain("negatives not allowed");

        private static Calculator _calculator;
        private static int _answer;
        private static Exception _exception;
    }

    [Subject("Calculator")]
    public class When_adding_1001_and_2
    {
        Establish context = () =>
        {
             _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("1001,2");

        It should_equal_2 = () => _answer.ShouldEqual(2);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_given_a_custom_delimter_of_any_length
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("//[***]\n1***2***3");

        It should_equal_6 = () => _answer.ShouldEqual(6);

        private static Calculator _calculator;
        private static int _answer;
    }

    [Subject("Calculator")]
    public class When_given_multiple_custom_delimiters
    {
        Establish context = () =>
        {
            _calculator = new Calculator();
        };

        Because of = () => _answer = _calculator.Add("//[**][%]\n1%2**3");

        It should_equal_6 = () => _answer.ShouldEqual(6);

        private static Calculator _calculator;
        private static int _answer;
    }
}
