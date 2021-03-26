using System.Collections.Generic;

namespace RendezvousWithCassidooChallenges
{
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
