using System;
class Program
{
  static void Main()
  {
#if DEBUG
    System.Console.WriteLine("DEBUG");
    int a = 15;
    int b = 16;
    int c = a * b;
    Console.WriteLine(c);
#endif
#if RELEASE
    System.Console.WriteLine("RELEASE");
    int a = 12;
    int b = 20;
    int c = a * b;
    Console.WriteLine(c);
#endif
#if TESTING
    System.Console.WriteLine("TESTING");
    int a = 100;
    int b = 30;
    int c = a * b;
    Console.WriteLine(c);
#endif
  }
}