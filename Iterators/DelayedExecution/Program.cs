using System;
using System.Collections.Generic;

namespace DelayedExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = MyIterator();
            var s2 = MyIterator();
            Console.WriteLine("I have 2 sequences.");
            foreach (int e in s2)
                Console.WriteLine(e);

            // Output
            // I have 2 sequences.
            // Ready
            // 1
            // Done
        }

        public static IEnumerable<int> MyIterator()
        {
            Console.WriteLine("Ready");
            yield return 1;
            Console.WriteLine("Done");
        }
    }
}
