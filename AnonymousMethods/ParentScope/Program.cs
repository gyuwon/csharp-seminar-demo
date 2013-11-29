using System;
using System.Collections.Generic;
using System.Text;

namespace ParentScope
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
        static void Main(string[] args)
        {
            StringBuilder messageBuilder = new StringBuilder();
            int value = 0;

            JobBuffer jobBuffer = new JobBuffer();
            jobBuffer.Push(delegate()
            {
                messageBuilder.Append("Hello");
                value += 1;
            });
            jobBuffer.Push(delegate()
            {
                messageBuilder.Append(", World!");
                value += 10;
            });

            Console.WriteLine("Message: {0}", messageBuilder.ToString());
            Console.WriteLine("Value: {0}", value);

            jobBuffer.Flush();

            Console.WriteLine("Message: {0}", messageBuilder.ToString());
            Console.WriteLine("Value: {0}", value);
        }
    }
}
