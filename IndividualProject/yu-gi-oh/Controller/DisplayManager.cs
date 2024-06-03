using System;
using System.Collections.Generic;

public class DisplayManager
{
  private Player player1;
  private Player player2;

  public DisplayManager(Player p1, Player p2)
  {
    player1 = p1;
    player2 = p2;
  }

  public void RefreshDisplay()
  {
    // Console.Clear();
    PrintYuGiOhGrid();
    ShowState(player1, player2);
    Console.WriteLine();
  }

  public void ShowState(Player currentPlayer, Player opponentPlayer)
  {
    Console.WriteLine($"{currentPlayer.Name}'s Hand:");
    for (int i = 0; i < currentPlayer.Hand.Count; i++)
    {
      Console.WriteLine($"  {i + 1}. {currentPlayer.Hand[i]}");
    }

    Console.WriteLine($"{currentPlayer.Name}'s Monster Field:");
    for (int i = 1; i <= currentPlayer.MonsterField.Length; i++)
    {
      Console.WriteLine($"  {i}. {currentPlayer.MonsterField[i - 1]?.ToString() ?? " "}");
    }

    Console.WriteLine($"{currentPlayer.Name}'s Trap Field:");
    for (int i = 1; i <= currentPlayer.TrapField.Length; i++)
    {
      Console.WriteLine($"  {i}. {currentPlayer.TrapField[i - 1]?.ToString() ?? " "}");
    }

    Console.WriteLine($"{opponentPlayer.Name}'s Monster Field:");
    for (int i = 1; i <= opponentPlayer.MonsterField.Length; i++)
    {
      Console.WriteLine($"  {i}. {opponentPlayer.MonsterField[i - 1]?.ToString() ?? " "}");
    }

    Console.WriteLine($"{opponentPlayer.Name}'s Trap Field:");
    for (int i = 1; i <= opponentPlayer.TrapField.Length; i++)
    {
      Console.WriteLine($"  {i}. {opponentPlayer.TrapField[i - 1]?.ToString() ?? " "}");
    }
  }

  public void PrintYuGiOhGrid()
  {
    Dictionary<int, string> cardPositions = Tile.InitializeCardPositions();
    // put card position
    for (int i = 1; i <= 5; i++)
    {
      cardPositions[i] = Tile.GetCardSymbol(player2.TrapField[i - 1]);
      cardPositions[i + 5] = Tile.GetCardSymbol(player2.MonsterField[i - 1]);
      cardPositions[i + 10] = Tile.GetCardSymbol(player1.MonsterField[i - 1]);
      cardPositions[i + 15] = Tile.GetCardSymbol(player1.TrapField[i - 1]);
    }

    // Print the grid with fixed player names and deck information
    string row1 = $"==================== {player1.Name} ===================";
    string row2 = $"==================== {player2.Name} ===================";
    string row3 = $"=================================================";
    string space = $"||                                             ||";

    Console.WriteLine("");
    Console.WriteLine(row1);
    Console.WriteLine(space);
    PrintRow(1, 5, cardPositions, $" (1-5 Spell Card)   || {player1.Name} HP: {player1.Health}");
    PrintRow(6, 10, cardPositions, $" (1-5 Monster Card) || Deck: [{player1.Deck.Cards.Count}] Cards");
    Console.WriteLine(space);
    Console.WriteLine(row3);
    Console.WriteLine(space);
    PrintRow(11, 15, cardPositions, $" (1-5 Monster Card) || {player2.Name} HP: {player2.Health}");
    PrintRow(16, 20, cardPositions, $" (1-5 Spell Card)   || Deck: [{player2.Deck.Cards.Count}] Cards");
    Console.WriteLine(space);
    Console.WriteLine(row2);
    Console.WriteLine("");
  }

  private void PrintRow(int start, int end, Dictionary<int, string> cardPositions, string extra = "")
  {
    Console.Write("||");
    for (int i = start; i <= end; i++)
    {
      Console.Write($" {cardPositions[i]} ");
    }
    Console.Write(extra);
    Console.WriteLine();
  }
}
