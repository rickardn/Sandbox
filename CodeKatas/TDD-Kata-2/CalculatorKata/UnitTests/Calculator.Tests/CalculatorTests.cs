// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;

namespace CalculatorKata.Tests {
    [TestFixture]
    public class CalculatorTests {
        [Test]
        public void Add_EmptyString_ReturnsZero() {
            var result = Add("");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_OneNumber_ReturnsNumber() {
            var result = Add("1");
            Assert.AreEqual(1, result);
        }

        [TestCase(3, "1,2")]
        [TestCase(10, "1,2,3,4")]
        public void Add_MultipleNumbersSeparatedByDelimiter_ReturnsSum(int expected, string value) {
            var result = Add(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_NewLineAsDelimiter_ReturnsSum() {
            var result = Add("1\n2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_ChangeDelimiter_ReturnsSum() {
            var result = Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_LessThanZero_ThrowsException() {
            TestDelegate add = () => Add("-1");
            Assert.Throws<Exception>(add);
        }

        private static int Add(string value)
        {
            return new Calculator().Add(value);
        }
    }
}