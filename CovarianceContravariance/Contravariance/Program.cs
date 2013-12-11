using System;

namespace Contravariance
{
    abstract class Programmer
    {
        public abstract string Language { get; }
        public abstract string Tool { get; }
    }

    enum DotNetLanguage
    {
        CSharp,
        VisualBasic,
        FSharp,
        IronPython,
        IronRuby,
        Clojure
    }

    class DotNetProgrammer : Programmer
    {
        public DotNetLanguage DotNetLanguage { get; set; }

        public override string Language
        {
            get
            {
                return this.DotNetLanguage.ToString();
            }
        }

        public override string Tool
        {
            get { return "Visual Studio"; }
        }
    }

    class Program
    {
        private static DotNetProgrammer _programmer = new DotNetProgrammer
        {
            DotNetLanguage = DotNetLanguage.CSharp
        };

        static void Main(string[] args)
        {
            // You don't need to do like this anymore.
            // - DoSomething(p => PrintLanguage(p));
            DoSomething(PrintLanguage);
        }

        static void PrintLanguage(Programmer programmer)
        {
            Console.WriteLine(programmer.Language);
        }

        static void DoSomething(Action<DotNetProgrammer> action)
        {
            action(_programmer);
        }
    }
}
