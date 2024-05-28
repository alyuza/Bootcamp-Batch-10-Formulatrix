// class Program
// {
//   static void Main()
//   {
//     string result = String.Empty;
//     int iteration = 10000;
//     for (int i = 0; i < iteration; i++)
//     {
//       result += "Hello";
//       result += "Yuza";
//       Console.Write(result);
//     }
//   }
// }

// Dispose
// class Program
// {
//   static void Main()
//   {
//     Garbage squid = new();
//     squid.Greeting();
//     GC.Collect();
//     // Console.ReadKey();
//   }
// }

// class Garbage
// {
//   public void Greeting()
//   {
//     Console.WriteLine("Hello Squid");
//   }
// }

// String Comparison
// using System;
// using System.Diagnostics;

// class Program
// {
//   static void Main()
//   {
//     string text = string.Empty;
//     Stopwatch stopwatch = new Stopwatch();
//     stopwatch.Start();
//     for (int i = 0; i < 1000000; i++)
//     {
//       text += "a";
//       text += "b";
//       text = text.Replace('a', 'c');
//     }
//     stopwatch.Stop();
//     Console.WriteLine(stopwatch.ElapsedMilliseconds);
//   }
// }

// String Builder Comprison
// using System;
// using System.Text;
// using System.Diagnostics;

// class Program
// {
//   static void Main()
//   {
//     StringBuilder text = new();
//     Stopwatch stopwatch = new Stopwatch();
//     stopwatch.Start();
//     for (int i = 0; i < 10000000; i++)
//     {
//       text.Append("a");
//       text.Append("b");
//       text.Append("c");
//     }
//     stopwatch.Stop();
//     Console.WriteLine(stopwatch.ElapsedMilliseconds);
//   }
// }

// class Car
// {
//   public Car()
//   {
//     Console.WriteLine("Constructor are created");
//   }
//   ~Car()
//   {
//     Console.WriteLine("Desctructor are created");
//   }
// }

// class Program
// {
//   static void Main()
//   {
//     Car car = new();
//     Console.ReadKey();
//   }
// }