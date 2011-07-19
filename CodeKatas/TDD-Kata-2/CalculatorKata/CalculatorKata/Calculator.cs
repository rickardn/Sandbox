using System;
using System.Collections.Generic;

namespace CalculatorKata
{
    public class Calculator
    {
        private const string NegativesAreNotAllowed = "Negatives are not allowed";
        private readonly List<char> delimiters = new List<char> {',', '\n'};
        private string value;

        public IConsole Console { get; set; }

        public int Add(string valueString)
        {
            var result = CalculateSum(valueString);
            OutputLine(result.ToString());
            return result;
        }

        private void OutputLine(string valueString)
        {
            if (Console != null)
            {
                Console.WriteLine(valueString);
            }
        }

        private int CalculateSum(string valueString)
        {
            var sum = 0;
            value = valueString;

            HandleEmptyValue()
                .HandleDelimiterSection()
                .ExtractValues()
                .ForEach(val => sum += val);

            return sum;
        }

        private Calculator HandleEmptyValue()
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                value = "0";
            }
            return this;
        }

        private Calculator HandleDelimiterSection()
        {
            if (value.StartsWith("//"))
            {
                delimiters.Add(value[2]);
                value = value.Substring(4);
            }
            return this;
        }

        private List<int> ExtractValues()
        {
            var values = new List<int>();
            Array.ForEach(
                value.Split(delimiters.ToArray()),
                ExtractValue(values));
            return values;
        }

        private Action<string> ExtractValue(List<int> values)
        {
            return s =>
            {
                var number = int.Parse(s);
                HandleNegatives(number);
                values.Add(number);
            };
        }

        private void HandleNegatives(int number)
        {
            if (number < 0)
            {
                OutputLine("Error: " + NegativesAreNotAllowed);
                throw new Exception(NegativesAreNotAllowed);
            }
        }
    }
}