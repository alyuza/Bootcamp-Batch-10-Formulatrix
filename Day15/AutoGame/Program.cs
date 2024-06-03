using System;
using System.Threading.Tasks;
using When;

class Program
{
  static async Task Main(string[] args)
  {
    var game = new Game("Yuza", "Fadl");

    while (!game.IsGameOver)
    {
      await game.PlayTurn();
      await Task.Delay(3000); // Wait for a second between turns
    }

    Console.WriteLine("Game Over!");
  }
}