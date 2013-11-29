using System;
using System.Collections.Generic;
using System.Text;

namespace Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            int? z = null;
            Console.WriteLine((x < y) == !(x >= y));
            Console.WriteLine((x < z) == !(x >= z));

            // Output
            // True
            // False
        }
    }
}
