using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RendezvousWithCassidooChallenges
{
    [TestClass]
    public class Solutions
    {
        /// <summary>
        /// You’re given two integer arrays (n and m), and an integer k. Using the digits from n and m, return the largest number you can of length k.
        ///
        /// Example:
        /// n = [3,4,6,5]
        /// m = [9,0,2,5,8,3]
        /// k = 5
        /// $ maxNum(n, m, k)
        /// $ 98655
        /// </summary>
        [TestMethod]
        public void Challenge_20210322()
        {
            // Arrange
            int[] n = { 3, 4, 6, 5 };
            int[] m = { 9, 0, 2, 5, 8, 3 };
            int k = 5;

            // Act
            var result = MaxNum(n, m, k);

            // Assert
            Assert.AreEqual(98655, result);
        }

        private static int MaxNum(int[] firstArray, int[] secondArray, int length) => firstArray.ToList()
            .Combine(secondArray)
            .Take(length)
            .Select(n => n.ToString())
            .StringJoin()
            .ToInt();
    }
}
