class Program
{
  static void Main()
  {
    Task attack = new Task(() =>
    {
      Thread.Sleep(2000);
      Console.WriteLine("Kaiba attacks Yugi");

    });
    Task defense = new Task(() =>
    {
      Console.WriteLine("Player 2 defense");
      Thread.Sleep(10000);
      Console.WriteLine("Yugi attacked by Kaiba");
    });

    Console.WriteLine("Player 1 turn to Attack");
    attack.Start();
    defense.Start();

    Task.WaitAll(attack, defense);
  }
}