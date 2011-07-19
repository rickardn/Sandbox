// ReSharper disable InconsistentNaming

using Moq;
using NUnit.Framework;

namespace CalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorConsoleAppTests
    {
        private const string resultIs = "Result is ";
        private Mock<IConsole> consoleMock;
        private CalculatorConsoleApp calculatorConsoleApp;
        private const string SomeValidInput = "1";

        [SetUp]
        public void BeforeAll()
        {
            consoleMock = new Mock<IConsole>();
            calculatorConsoleApp = new CalculatorConsoleApp(
                consoleMock.Object, 
                new Calculator());
        }

        [Test]
        public void Main_EmptyArg_OutputsResultIsZero()
        {
            Main("");
            VerifyOutputedLine(ResultIs("0"));
        }

        [Test]
        public void Main_SingleValue_OutputsResultIsValue()
        {
            Main("1");
            VerifyOutputedLine(ResultIs("1"));
        }

        [TestCase("1,2,3", "6")]
        [TestCase("1,2,3,4", "10")]
        public void Main_MultipleValues_OutputsResultIsSum(string value, string expected)
        {
            Main(value);
            VerifyOutputedLine(ResultIs(expected));
        }

        [Test]
        public void Main_NegativeValues_OutputsErrorMessage()
        {
            Main("-1");
            VerifyOutputedLine("Error: Negatives are not allowed");
        }

        [Test]
        public void Main_Allways_OutputsAnotherInputPlease()
        {
            Main(SomeValidInput);
            VerifyOutputedLine("another input please");
        }

        [Test]
        public void Main_Allways_PromptsForAnotherInput()
        {
            Main(SomeValidInput);
            consoleMock.Verify(console => console.ReadLine());
        }

        [Test]
        public void Main_UserEntersEmptyValue_ProgramExits()
        {
            consoleMock.Setup(console => console.ReadLine())
                .Returns("");
            Main(SomeValidInput);
            VerifyReadLine(Times.Exactly(1));
        }

        [Test]
        public void Main_UserEntersNonEmptyValue_OutputsNewSum()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("");
            Main(SomeValidInput);
            VerifyOutputedLine(ResultIs("2"));
        }

        [Test]
        public void Main_UserEntersNonEmpytValue_PromtsForAnotherInputUntilEmpty()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("");
            Main(SomeValidInput);
            VerifyReadLine(Times.Exactly(2));
        }

        [Test]
        public void Main_UserEntersNonEmpytValue_PromtsForAnotherInputUntilEmpty2()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("3")
                .Returns("");
            Main(SomeValidInput);
            VerifyReadLine(Times.Exactly(3));
        }

        [Test]
        public void Main_UserEntersNonEmpytValue_PromtsForAnotherInputUntilEmpty3()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("3")
                .Returns("4")
                .Returns("");
            Main(SomeValidInput);
            VerifyReadLine(Times.Exactly(4));
        }

        [Test]
        public void Main_UserEntersNonEmpytValue_PromtsForAnotherInputUntilEmpty4()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("3")
                .Returns("4")
                .Returns("4")
                .Returns("4")
                .Returns("1,2,3")
                .Returns("");
            Main(SomeValidInput);
            VerifyReadLine(Times.Exactly(7));
        }

        [Test]
        public void Main_UserEnterNonEmptyValue_OutputsNewSum2()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("3")
                .Returns("");
            Main(SomeValidInput);
            VerifyOutputedLine(ResultIs("3"));
        }

        [Test]
        public void Main_UserEnterNonEmptyValue_OutputsNewSum3()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("3")
                .Returns("4")
                .Returns("");
            Main(SomeValidInput);
            VerifyOutputedLine(ResultIs("4"));
        }

        [Test]
        public void Main_UserEnterNonEmptyValue_OutputsNewSum4()
        {
            consoleMock.SetupSequence(console => console.ReadLine())
                .Returns("2")
                .Returns("3")
                .Returns("4")
                .Returns("4")
                .Returns("4")
                .Returns("1,2,3")
                .Returns("");
            Main(SomeValidInput);
            VerifyOutputedLine(ResultIs("6"));
        }

        private void VerifyReadLine(Times times)
        {
            consoleMock.Verify(console => console.ReadLine(), times);
        }

        private static string ResultIs(string expected)
        {
            return resultIs + expected;
        }

        private void VerifyOutputedLine(string expected)
        {
            consoleMock.Verify(console => console.WriteLine(expected));
        }

        private void Main(string value)
        {
            calculatorConsoleApp.Main(new[] {value});
        }
    }
}
