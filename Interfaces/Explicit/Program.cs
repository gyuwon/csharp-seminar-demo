using System;

namespace Explicit
{
    interface IMyIntf1 { string Foo(); }
    interface IMyIntf2 { string Foo(); }

    class MyClass : IMyIntf1, IMyIntf2
    {
        public string Foo() { return "Hello"; }
        string IMyIntf2.Foo() { return "World"; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myObj = new MyClass();
            IMyIntf1 myIntf1 = myObj;
            IMyIntf2 myIntf2 = myObj;

            Console.WriteLine(myObj.Foo());
            Console.WriteLine(myIntf1.Foo());
            Console.WriteLine(myIntf2.Foo());

            // Output
            // Hello
            // Hello
            // World
        }
    }
}
