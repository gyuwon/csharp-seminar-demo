using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeArray();
            MakeListWithFirstElement();
            MakeListWithoutFirstElement();
        }

        static void MakeArray()
        {
            Console.WriteLine("* MakeArray");
            var array = new[]
            {
                new { Name = "Tony Stark", Email = "ironman@avengers.com" },
                new { Name = "Bruce Banner", Email = "hulk@avengers.com" }
            };
            foreach (var e in array)
            {
                Console.WriteLine(e);
            }
        }

        static void MakeListWithFirstElement()
        {
            Console.WriteLine("* MakeListWithFirstElement");
            var list = new[] { new { Name = "Tony Stark", Email = "ironman@avengers.com" } }.ToList();
            list.Add(new { Name = "Bruce Banner", Email = "hulk@avengers.com" });
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
        }

        static void MakeListWithoutFirstElement()
        {
            Console.WriteLine("* MakeListWithoutFirstElement");
            var list = NewList(() => new { Name = "", Email = "" });
            list.Add(new { Name = "Tony Stark", Email = "ironman@avengers.com" });
            list.Add(new { Name = "Bruce Banner", Email = "hulk@avengers.com" });
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
        }

        static List<T> NewList<T>(Func<T> descriptor)
        {
            return new List<T>();
        }
    }
}
