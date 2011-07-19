// ReSharper disable InconsistentNaming

using Moq;
using NUnit.Framework;

namespace CalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorOutputTests
    {
        private Mock<IConsole> consoleMock;
        private Calculator calculator;

        [SetUp]
        public void BeforeAll()
        {
            consoleMock = new Mock<IConsole>();
            calculator = new Calculator
            {
                Console = consoleMock.Object
            };
        }

        [Test]
        public void Add_EmptyValue_OutputsZero()
        {
            Add("");
            VerifyOutputedLine("0");
        }

        [Test]
        public void Add_SingleValue_OutputsValue()
        {
            Add("1");
            VerifyOutputedLine("1");
        }

        [TestCase("1,2,3", "6")]
        [TestCase("1,2,3,4", "10")]
        public void Add_MultipleValues_OutputsSum(string value, string expected)
        {
            Add(value);
            VerifyOutputedLine(expected);
        }

        [Test]
        public void Add_NewlineDelimiter_OutputsSum()
        {
            Add("1\n2");
            VerifyOutputedLine("3");
        }

        [Test]
        public void Add_NegativeValue_OutputsErrorMessage()
        {
            try {Add("-1");} catch {}
            VerifyOutputedLine("Error: Negatives are not allowed");
        }

        private void VerifyOutputedLine(string expected)
        {
            consoleMock.Verify(console => console.WriteLine(expected));
        }

        private void Add(string value)
        {
            calculator.Add(value);
        }
    }
}
