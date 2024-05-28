class Program
{
  static void Main()
  {
    Cards();
    Spells();
  }

  static void Cards()
  {
    Console.WriteLine("This is Cards");
    Console.WriteLine("Run in thread: " + Thread.CurrentThread.ManagedThreadId);
  }
  static void Spells()
  {
    Console.WriteLine("This is Spells");
    Console.WriteLine("Run in thread: " + Thread.CurrentThread.ManagedThreadId);
  }
}