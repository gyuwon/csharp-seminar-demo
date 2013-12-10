using System;
using System.Diagnostics;

namespace StaticallyTypedObject
{
    class Counter
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

            using (Job.StartNew("Static Binding"))
            {
                Counter counter = new Counter();
                for (int i = 0; i < n; i++)
                    counter.Increase();
                Console.WriteLine("Count: {0}", counter.Count);
            }

            using (Job.StartNew("Dynamic Binding"))
            {
                dynamic counter = new Counter();
                for (int i = 0; i < n; i++)
                    counter.Increase();
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
