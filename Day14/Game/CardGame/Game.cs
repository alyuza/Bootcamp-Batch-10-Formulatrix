namespace CardGame
{
  public class Game
  {
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public bool IsGameOver { get; private set; }

    public Game(string player1Name, string player2Name)
    {
      Player1 = new Player(player1Name);
      Player2 = new Player(player2Name);
      IsGameOver = false;
    }

    public void PlayTurn()
    {
      if (!IsGameOver)
      {
        Player1.Attack(Player2, Player1.Deck[0]);
        if (Player2.Health <= 0)
        {
          Console.WriteLine($"{Player2.Name} is defeated! {Player1.Name} wins!");
          IsGameOver = true;
          return;
        }

        Player2.Attack(Player1, Player2.Deck[0]);
        if (Player1.Health <= 0)
        {
          Console.WriteLine($"{Player1.Name} is defeated! {Player2.Name} wins!");
        }
      }
    }
  }
}