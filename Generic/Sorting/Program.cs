using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;

            ArrayList arrayList = new ArrayList(n);
            List<int> genericList = new List<int>(n);

            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int value = random.Next();
                arrayList.Add(value);
                genericList.Add(value);
            }

            using (Job.StartNew("ArrayList Sort"))
            {
                arrayList.Sort();
            }

            using (Job.StartNew("List<int> sort"))
            {
                genericList.Sort();
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
