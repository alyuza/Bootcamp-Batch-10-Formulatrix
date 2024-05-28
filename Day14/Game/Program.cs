namespace CardGame
{
  class Program
  {
    static void Main(string[] args)
    {
      Game game = new Game("Yugi", "Kaiba");

      // Add some cards to each player's deck
      game.Player1.Deck.Add(new Card("Dragon", 20));
      game.Player1.Deck.Add(new Card("Warrior", 15));
      game.Player2.Deck.Add(new Card("Goblin", 10));
      game.Player2.Deck.Add(new Card("Orc", 18));

      // Main game loop
      while (!game.IsGameOver)
      {
        game.PlayTurn();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
      }

      Console.WriteLine("Game over. Press Enter to exit.");
      Console.ReadLine();
    }
  }
}