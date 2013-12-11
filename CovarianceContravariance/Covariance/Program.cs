using System;
using System.Collections.Generic;
using System.Linq;

namespace Covariance
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
        static void Main(string[] args)
        {
            var languages = (DotNetLanguage[])Enum.GetValues(typeof(DotNetLanguage));

            Random random = new Random();

            IEnumerable<DotNetProgrammer> dotNetProgrammers =
                from i in Enumerable.Range(0, 10)
                select new DotNetProgrammer
                {
                    DotNetLanguage = languages[random.Next(languages.Length)]
                };

            WriteLanguages(dotNetProgrammers);
        }

        static void WriteLanguages(IEnumerable<Programmer> programmers)
        {
            foreach (var programmer in programmers)
            {
                Console.WriteLine(programmer.Language);
            }
        }
    }
}
