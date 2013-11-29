using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Performance
{
    interface ICounter
    {
        long Count { get; }
        void Increase();
    }

    class CounterClass : ICounter
    {
        private long _count;
        public long Count { get { return this._count; } }

        public void Increase()
        {
            this._count++;
        }
    }

    struct CounterStruct : ICounter
    {
        private long _count;
        public long Count { get { return this._count; } }

        public void Increase()
        {
            this._count++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000000;
            using (Job.StartNew("CounterClass"))
            {
                CounterClass counter = new CounterClass();
                for (int i = 0; i < n; i++)
                    counter.Increase();
                Console.WriteLine("Count: {0}", counter.Count);
            }

            Console.WriteLine();

            using (Job.StartNew("CounterStruct"))
            {
                CounterStruct counter = new CounterStruct();
                for (int i = 0; i < n; i++)
                    counter.Increase();
                Console.WriteLine("Count: {0}", counter.Count);
            }

            Console.WriteLine();

            using (Job.StartNew("CounterStruct via Interface"))
            {
                ICounter counter = new CounterStruct();
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
