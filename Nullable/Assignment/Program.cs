using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int? x = null;
            double y;
            double? z;

            y = x;
            // Cannot implicitly convert type 'int?' to 'double'.

            y = (double)x;
            // InvalidOperationException: Nullable object must have a value.

            z = x;
        }
    }
}
