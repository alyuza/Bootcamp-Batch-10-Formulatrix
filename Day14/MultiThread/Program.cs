class Program
{
  static void Main()
  {
    Thread thread1 = new(NormalCards);
    Thread thread2 = new(SpellCards);

    thread1.IsBackground = true; // mengubah foreground thread menjadi background thread
    thread1.Name = "thread name = NormalCards";
    thread2.Priority = ThreadPriority.Normal;

    thread1.Start();
    thread2.Start();

    thread1.Join(); // method untuk menyelesaikan thread walaupun di dalam background
    thread1.Join(); // method untuk menyelesaikan thread walaupun di dalam background
  }

  static void NormalCards()
  {
    for (int i = 0; i < 100; i++)
    {
      Console.WriteLine($"Normal Cards: {i}. Thread: " + Thread.CurrentThread.ManagedThreadId);
      Thread.Sleep(1000); // pause for 1 second
    }
  }
  static void SpellCards()
  {
    for (int i = 0; i < 100; i++)
    {
      Console.WriteLine($"Spell Cards: {i}. Thread: " + Thread.CurrentThread.ManagedThreadId);
      Thread.Sleep(1000); // pause for 1 second
    }
  }
}