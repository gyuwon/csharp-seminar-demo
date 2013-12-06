using System;
using System.Linq;

namespace FluentApiVsQueryExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            WhereOrderBy();

            Console.WriteLine();

            WithLet();
        }

        private static void WhereOrderBy()
        {
            var contacts = new[]
            {
                new { Name = "Tony Stark", Email = "ironman@avengers.com", Species = "Human" },
                new { Name = "Bruce Banner", Email = "hulk@avengers.com", Species = "Human" },
                new { Name = "Thor Odinson", Email = "thor@avengers.com", Species = "Asgardian" }
            };

            var query1 = from c in contacts
                         where c.Species == "Human"
                         orderby c.Name
                         select c;

            foreach (var contact in query1)
                Console.WriteLine(contact);

            Console.WriteLine();

            var query2 = contacts
                .Where(c => c.Species == "Human")
                .OrderBy(c => c.Name);

            foreach (var contact in query2)
                Console.WriteLine(contact);
        }

        private static void WithLet()
        {
            var strings = new[]
            {
                "Invincible Ironman",
                "Pepper Potts",
                "Silver Surfer",
                "Bruce Banner",
                "Fantastic Four",
                "Sue Storm",
                "Thor Odinson",
                "Doctor Doom",
                "Peter Parker",
                "Green Goblin"
            };

            var query1 = from s in strings
                         let split = s.Split(' ')
                         where
                             split.Length >= 2 &&
                             split[0][0] == split[1][0]
                         orderby
                             split[1]
                         select s;

            foreach (var s in query1)
                Console.WriteLine(s);

            Console.WriteLine();

            var query2 = strings
                .Select(s => new
                {
                    Split = s.Split(' '),
                    String = s
                })
                .Where(e => e.Split[0][0] == e.Split[1][0])
                .OrderBy(e => e.Split[1])
                .Select(e => e.String);

            foreach (var s in query1)
                Console.WriteLine(s);
        }
    }
}
