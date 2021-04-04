using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RendezvousWithCassidooChallenges
{
    [TestClass]
    public class Issue189
    {
        /// <summary>
        /// Given a string, return true if the string represents a valid number. A valid number can include integers, a ., -, or +.
        /// </summary>
        [TestMethod]
        [DataRow("7", true)]
        [DataRow("0011", true)]
        [DataRow("+3.14", true)]
        [DataRow("4.", true)]
        [DataRow("-.9", true)]
        [DataRow("-123.456", true)]
        [DataRow("-0.1", true)]
        [DataRow("abc", false)]
        [DataRow("1a", false)]
        [DataRow("e8", false)]
        [DataRow("--6", false)]
        [DataRow("-+3", false)]
        [DataRow("95x54e53.", false)]
        [DataRow("95x54e53.", false)]
        [DataRow("-", false)]
        [DataRow("..3", false)]
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
    }
}
