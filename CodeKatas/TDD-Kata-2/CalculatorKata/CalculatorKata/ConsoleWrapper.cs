using System;

namespace CalculatorKata
{
    public class ConsoleWrapper : IConsole {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}