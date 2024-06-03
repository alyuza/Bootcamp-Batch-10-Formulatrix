using System;

public class Game
{
  private Player player1;
  private Player player2;
  private bool isPlayer1Turn;
  private DisplayManager displayManager;
  private PlayerActions playerActions;

  public Game(Player p1, Player p2)
  {
    player1 = p1;
    player2 = p2;
    isPlayer1Turn = true;
    displayManager = new DisplayManager(player1, player2);
    playerActions = new PlayerActions(displayManager);
  }

  public void StartGame()
  {
    Console.Clear();

    player1.Deck.Shuffle();
    player2.Deck.Shuffle();

    while (player1.Health > 0 && player2.Health > 0)
    {
      Player currentPlayer = isPlayer1Turn ? player1 : player2;
      Player opponentPlayer = isPlayer1Turn ? player2 : player1;

      if (isPlayer1Turn)
      {
        Console.ForegroundColor = ConsoleColor.Red;
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Blue;
      }
      Console.WriteLine($"{currentPlayer.Name}'s turn.");
      Console.ResetColor();

      currentPlayer.DrawCard();
      RefreshDisplay(currentPlayer, opponentPlayer);
      playerActions.PlaceCardOnField(currentPlayer);
      playerActions.Attack(currentPlayer, opponentPlayer);

      isPlayer1Turn = !isPlayer1Turn; // switch turn
    }

    Player winner = player1.Health > 0 ? player1 : player2;
    Console.WriteLine($"{winner.Name} wins the game!");
  }

  public void RefreshDisplay(Player currentPlayer, Player opponentPlayer)
  {
    Console.Clear();
    displayManager.PrintYuGiOhGrid(currentPlayer, opponentPlayer);
    displayManager.ShowState(currentPlayer, opponentPlayer);
  }
}