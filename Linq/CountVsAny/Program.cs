using System;
using System.Collections.Generic;
using System.Linq;

namespace CountVsAny
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> jedi = Jedi();

            Console.WriteLine(jedi.Count() > 0 ? "Hopeful" : "Hopeless");
            Console.WriteLine(jedi.Any() ? "Hopeful" : "Hopeless");
        }

        public static IEnumerable<string> Jedi()
        {
            Console.WriteLine(1);
            yield return "Luke";

            Console.WriteLine(2);
            yield return "Yoda";

            Console.WriteLine(3);
            yield return "Qui-Gon";

            Console.WriteLine(4);
            yield return "Obiwan";

            Console.WriteLine(5);
            yield return "Windu";
        }
    }
}
