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
    while (player1.Health > 0 && player2.Health > 0)
    {
      Player currentPlayer = isPlayer1Turn ? player1 : player2;
      Player opponentPlayer = isPlayer1Turn ? player2 : player1;

      Console.Clear();
      // displayManager.RefreshDisplay();
      displayManager.PrintYuGiOhGrid();
      Console.WriteLine($"{currentPlayer.Name}'s turn.");
      currentPlayer.DrawCard();
      displayManager.ShowState(currentPlayer, opponentPlayer); // show current state
      playerActions.PlaceCardOnField(currentPlayer); // put card
      playerActions.Attack(currentPlayer, opponentPlayer);
      playerActions.ActivateTrap(opponentPlayer);
      isPlayer1Turn = !isPlayer1Turn; // switch turns
    }

    Player winner = player1.Health > 0 ? player1 : player2;
    Console.WriteLine($"{winner.Name} wins the game!");
  }
}
