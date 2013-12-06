using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomQueryExpression
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "Ironman", "Hulk", "Thor" };
            var sequence = (IEnumerable<string>)array;

            var q1 = from a in array
                     where a.Length > 4
                     select a;
            foreach (var e in q1)
                Console.WriteLine(e);

            var q2 = from a in sequence
                     where a.Length > 4
                     select a;
            foreach (var e in q2)
                Console.WriteLine(e);
        }

        public static string Where(this string[] s, Func<string, bool> predicate)
        {
            return "Where?";
        }
    }
}
