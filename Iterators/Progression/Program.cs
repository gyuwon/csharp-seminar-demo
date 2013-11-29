using System;
using System.Collections;
using System.Collections.Generic;

namespace Progression
{
    class ArithmeticProgressionEnumerable : IEnumerable<double>
    {
        private double _init;
        private double _diff;
        private int _n;

        public ArithmeticProgressionEnumerable(double initialTerm, double difference, int count)
        {
            this._init = initialTerm;
            this._diff = difference;
            this._n = count;
        }

        public IEnumerator<double> GetEnumerator() { return new Enumerator(this); }
        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        private class Enumerator : IEnumerator<double>
        {
            private ArithmeticProgressionEnumerable _source;
            private int _pos;

            public Enumerator(ArithmeticProgressionEnumerable enumerable)
            {
                this._source = enumerable;
                this._pos = 0;
            }

            public double Current
            {
                get
                {
                    if (this._pos <= 0) throw new InvalidOperationException();
                    return this._source._init + this._source._diff * (this._pos - 1);
                }
            }

            public bool MoveNext()
            {
                if (this._pos >= this._source._n)
                    return false;
                this._pos++;
                return true;
            }

            public void Reset() { this._pos = 0; }
            public void Dispose() { }
            object IEnumerator.Current { get { return this.Current; } }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<double> s1 = new ArithmeticProgressionEnumerable(0.0, 1.0, 10);
            foreach (var e in s1)
                Console.WriteLine(e);

            Console.WriteLine();

            IEnumerable<double> s2 = ArithmeticProgression(0.0, 1.0, 10);
            foreach (var e in s2)
                Console.WriteLine(e);
        }

        static IEnumerable<double> ArithmeticProgression(double initialTerm, double difference, int count)
        {
            for (int i = 0; i < count; i++)
                yield return initialTerm + difference * i;
        }
    }
}
