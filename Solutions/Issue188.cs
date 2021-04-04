using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RendezvousWithCassidooChallenges
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
    [TestClass]
    public class Issue188
    {
        [TestMethod]
        public void Test()
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
            .OrderByDescending(i => i)
            .Take(length)
            .Select(n => n.ToString())
            .StringJoin()
            .ToInt();
    }

    public static class FluentExtensions
    {
        public static List<T> Combine<T>(this List<T> source, IEnumerable<T> other)
        {
            source.AddRange(other);
            return source;
        }

        public static string StringJoin(this IEnumerable<string> enumerable) =>
            string.Join(string.Empty, enumerable);

        public static int ToInt(this string stringValue) =>
            int.Parse(stringValue);
    }
}
