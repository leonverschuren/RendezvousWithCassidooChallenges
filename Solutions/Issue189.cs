using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RendezvousWithCassidooChallenges
{
    /// <summary>
    /// Given a string, return true if the string represents a valid number. A valid number can include integers, a ., -, or +.
    /// </summary>
    [TestClass]
    public class Issue189
    {
        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void Test(string input, bool isNumber)
        {
            // Arrange

            // Act
            bool result = IsNumber(input);

            // Assert
            Assert.AreEqual(isNumber, result);
        }

        private static bool IsNumber(string input)
        {
            return Regex.IsMatch(input, @"^[+-]{0,1}([0-9]+|([0-9]*\.[0-9]*))$");
        }

        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void TestAlt(string input, bool isNumber)
        {
            // Arrange

            // Act
            bool result = Parser.IsNumber(input);

            // Assert
            Assert.AreEqual(isNumber, result);
        }

        private static IEnumerable<object[]> GetTestCases()
        {
            return new[]
            {
                new object[] { "7", true },
                new object[] { "0011", true },
                new object[] { "+3.14", true },
                new object[] { "4.", true },
                new object[] { "-.9", true },
                new object[] { "-123.456", true },
                new object[] { "-0.1", true },
                new object[] { "abc", false },
                new object[] { "1a", false },
                new object[] { "e8", false },
                new object[] { "--6", false },
                new object[] { "-+3", false },
                new object[] { "95x54e53.", false },
                new object[] { "-", false },
                new object[] { "..3", false }
            };
        }
    }

    public class Parser
    {
        private static readonly IEnumerable<char> Modifiers = new[] { '+', '-' };
        private static readonly IEnumerable<char> Integers = Enumerable.Range(0, 10).SelectMany(r => r.ToString().ToCharArray());

        private readonly IEnumerable<char> _input;
        private bool _hasModifier;
        private bool _hasPeriod;
        private bool _hasNumbers;

        private Parser(string input)
        {
            _input = input.ToCharArray();
        }

        private bool IsNumber()
        {
            foreach (char c in _input)
            {
                if (c.In(Modifiers))
                {
                    if (_hasModifier)
                    {
                        // Multiple modifiers in input
                        return false;
                    }

                    if (_hasNumbers)
                    {
                        // Modifier is proceeded by number
                        return false;
                    }

                    _hasModifier = true;
                }
                else if (c == '.')
                {
                    if (_hasPeriod)
                    {
                        // Multiple periods in input
                        return false;
                    }

                    _hasPeriod = true;
                }
                else if (c.NotIn(Integers))
                {
                    return false;
                }
                else
                {
                    _hasNumbers = true;
                }
            }

            return _hasNumbers;
        }

        public static bool IsNumber(string input) => new Parser(input).IsNumber();
    }

    public static class EnumerableExtension
    {
        public static bool In<T>(this T value, IEnumerable<T> source) => source.Contains(value);
        public static bool NotIn<T>(this T value, IEnumerable<T> source) => !value.In(source);
    }
}
