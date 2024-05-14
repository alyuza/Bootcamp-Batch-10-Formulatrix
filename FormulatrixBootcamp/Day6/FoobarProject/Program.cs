// 3 foo
// 5 bar
// User input => n

// n = 15
// 0, 1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar

using System;
namespace FooBar
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please Input n value: ");
            int n = int.Parse(Console.ReadLine());
            Identifier.Check(n);
        }
    }

    class Identifier
    {
        public static void Check(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FooBar");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Foo");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Bar");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
