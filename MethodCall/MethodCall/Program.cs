using System;
using System.Diagnostics;
using System.Reflection;

namespace MethodCall
{
    interface ICounter
    {
        long Count { get; }
        void Increase();
    }

    delegate void Increase();

    class Counter : ICounter
    {
        private long _count;
        public long Count { get { return this._count; } }
        public void Increase() { this._count++; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 10000000;

            using (Job.StartNew("Direct"))
            {
                Counter counter = new Counter();
                for (int i = 0; i < n; i++)
                    counter.Increase();
                Console.WriteLine("Count: {0}", counter.Count);
            }

            Console.WriteLine();

            using (Job.StartNew("Delegate"))
            {
                Counter counter = new Counter();
                Increase increase = counter.Increase;
                for (int i = 0; i < n; i++)
                    increase();
                Console.WriteLine("Count: {0}", counter.Count);
            }

            Console.WriteLine();

            using (Job.StartNew("Reflection"))
            {
                Counter counter = new Counter();
                MethodInfo m = typeof(Counter).GetMethod("Increase", BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < n; i++)
                    m.Invoke(counter, null);
                Console.WriteLine("Count: {0}", counter.Count);
            }

            Console.WriteLine();

            using (Job.StartNew("CreateDelegate"))
            {
                Counter counter = new Counter();
                MethodInfo m = typeof(Counter).GetMethod("Increase", BindingFlags.Public | BindingFlags.Instance);
                Increase increase = (Increase)System.Delegate.CreateDelegate(typeof(Increase), counter, m);
                for (int i = 0; i < n; i++)
                    increase();
                Console.WriteLine("Count: {0}", counter.Count);
            }
        }
    }

    class Job : IDisposable
    {
        public static Job StartNew(string name)
        {
            return new Job(name);
        }

        private string _name;
        private Stopwatch _stopwatch;

        private Job(string name)
        {
            this._name = name;
            this._stopwatch = Stopwatch.StartNew();
            Console.WriteLine("[{0} started]", this._name);
        }

        public void Dispose()
        {
            this._stopwatch.Stop();
            Console.WriteLine("[{0} finished] {1}ms elapsed", this._name, this._stopwatch.ElapsedMilliseconds);
        }
    }
}
