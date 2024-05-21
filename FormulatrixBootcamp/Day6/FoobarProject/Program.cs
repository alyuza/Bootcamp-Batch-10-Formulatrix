// Case:
// 3 foo
// 5 bar
// User input => n, if n=15 print:
// 0, 1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar

using System;
using System.Collections.Generic;

namespace FoobarProject
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please Input n value: ");
            int n;

            if (int.TryParse(Console.ReadLine(), out n)) // Convert to int, karena melakukan perhitungan harus menggunakan tipe data numerik
            {
                // Call the Check method to get the results in a queue
                Queue<string> results = Identifier.Check(n);

                // looping dan print 1 per 1 berurutan (FIFO)
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer value.");
            }
        }
    }
}

