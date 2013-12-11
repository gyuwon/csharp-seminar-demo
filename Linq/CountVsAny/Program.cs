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
            int n = 0;

            Console.WriteLine(++n);
            yield return "Luke";

            Console.WriteLine(++n);
            yield return "Yoda";

            Console.WriteLine(++n);
            yield return "Qui-Gon";

            Console.WriteLine(++n);
            yield return "Obiwan";

            Console.WriteLine(++n);
            yield return "Windu";
        }
    }
}
