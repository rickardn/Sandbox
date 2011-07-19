namespace CalculatorKata
{
    public class Program
    {
        static void Main(string[] args)
        {
            new CalculatorConsoleApp(
                new ConsoleWrapper(),
                new Calculator())
                .Main(args);
        }
    }
}