using System;
using System.Collections.Generic;
using System.Text;

namespace ClosureImplementationModel
{
    delegate void Job();

    class JobBuffer
    {
        private List<Job> _buffer = new List<Job>();

        public void Push(Job job)
        {
            this._buffer.Add(job);
        }

        public void Flush()
        {
            foreach (Job job in this._buffer)
                job();
            this._buffer.Clear();
        }
    }

    class Program
    {
        class AnonymousMethods
        {
            public StringBuilder messageBuilder = new StringBuilder();
            public int value = 0;

            public void Method1()
            {
                messageBuilder.Append("Hello");
                value += 1;
            }

            public void Method2()
            {
                messageBuilder.Append(", World!");
                value += 10;
            }
        }

        static void Main(string[] args)
        {
            AnonymousMethods capsule = new AnonymousMethods();

            JobBuffer jobBuffer = new JobBuffer();
            jobBuffer.Push(capsule.Method1);
            jobBuffer.Push(capsule.Method2);

            Console.WriteLine("Message: {0}", capsule.messageBuilder.ToString());
            Console.WriteLine("Value: {0}", capsule.value);

            jobBuffer.Flush();

            Console.WriteLine("Message: {0}", capsule.messageBuilder.ToString());
            Console.WriteLine("Value: {0}", capsule.value);
        }
    }
}
