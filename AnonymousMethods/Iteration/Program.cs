using System;

namespace Iteration
{
    internal delegate int Proc();

    class Program
    {
        static void Main(string[] args)
        {
            Unexpected();
            Solution();
        }

        private static void Unexpected()
        {
            Proc[] procs = new Proc[5];
            for (int i = 0; i < procs.Length; i++)
                procs[i] = delegate() { return i * i; };

            foreach (Proc proc in procs)
                Console.WriteLine(proc());

            // Output
            // 25
            // 25
            // 25
            // 25
            // 25
            // Did you expect this?
        }

        private static void Solution()
        {
            Proc[] procs = new Proc[5];
            for (int i = 0; i < procs.Length; i++)
            {
                int n = i;
                procs[i] = delegate() { return n * n; };
            }

            foreach (Proc proc in procs)
                Console.WriteLine(proc());

            // Output
            // 0
            // 1
            // 4
            // 9
            // 16
        }
    }
}
