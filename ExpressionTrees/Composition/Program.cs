using System;
using System.Linq.Expressions;

namespace Composition
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression n = Expression.Parameter(typeof(int), "n");
            ConstantExpression twenty = Expression.Constant(20);
            BinaryExpression nGreaterThanTwenty = Expression.GreaterThan(n, twenty);
            var expression = Expression.Lambda<Func<int, bool>>(nGreaterThanTwenty, n);
            Console.WriteLine(expression);

            Func<int, bool> func = expression.Compile();
            Console.WriteLine(func(10));

            // Output
            // n => (n > 20)
            // False
        }
    }
}
