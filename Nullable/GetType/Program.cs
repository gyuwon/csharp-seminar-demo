using System;

namespace GetType
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int? y = 1;
            int? z = null;

            Console.WriteLine(typeof(int) == x.GetType());
            Console.WriteLine(typeof(int?) == y.GetType());
            Console.WriteLine(y.GetType());
            Console.WriteLine(z.GetType()); // System.NullReferenceException
        }
    }
}
