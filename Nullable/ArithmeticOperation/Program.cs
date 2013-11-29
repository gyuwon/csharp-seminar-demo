using System;

namespace ArithmeticOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 2;
            double? y = null;
            Write(x * y);
            y = 10;
            Write(x * y);

            // Output
            // null
            // 20
        }

        static void Write<T>(T? v) where T : struct
        {
            if (v == null) Console.WriteLine("null");
            else Console.WriteLine(v);
        }
    }
}
