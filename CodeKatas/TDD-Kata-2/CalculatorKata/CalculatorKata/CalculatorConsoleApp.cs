using System;

namespace CalculatorKata
{
    public class CalculatorConsoleApp {
        private readonly IConsole console;
        private readonly Calculator calculator;
        private int result;

        public CalculatorConsoleApp(IConsole console, Calculator calculator)
        {
            this.console = console;
            this.calculator = calculator;
        }

        public void Main(string[] args)
        {
            CalculateAndOutputSumOf(args[0]);
            PromptForAnotherValue();
        }

        private void PromptForAnotherValue()
        {
            OutputLine("another input please");
            var input = console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                CalculateAndOutputSumOf(input);
                PromptForAnotherValue();
            }
        }

        private void CalculateAndOutputSumOf(string input)
        {
            if (SuccessCalculatingSum(input))
            {
                OutputLine("Result is " + result);
            }
        }

        private bool SuccessCalculatingSum(string valueString)
        {
            var success = false;
            try
            {
                result = calculator.Add(valueString);
                success = true;
            }
            catch (Exception ex)
            {
                OutputLine("Error: " + ex.Message);
            }
            return success;
        }

        private void OutputLine(string value)
        {
            console.WriteLine(value);
        }
    }
}