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

  public void ShowState(Player currentPlayer, Player opponentPlayer)
  {
    Console.WriteLine("================================= HAND =================================");
    Console.WriteLine("");
    Console.WriteLine($"{currentPlayer.Name}'s Hand:");
    if (currentPlayer.Hand.Count == 0)
    {
      Console.WriteLine("No cards in hand.");
    }
    else
    {
      for (int i = 0; i < currentPlayer.Hand.Count; i++)
      {
        Console.WriteLine($"  {i + 1}. {currentPlayer.Hand[i]}");
      }
    }

    Console.WriteLine("");
    Console.WriteLine("================================= FIELD =================================");
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
    Console.WriteLine("=========================================================================");
    Console.WriteLine("");
  }

  public void PrintYuGiOhGrid(Player currentPlayer, Player opponentPlayer)
  {
    Dictionary<int, string> cardPositions = Tile.InitializeCardPositions();
    // put card position
    for (int i = 1; i <= 5; i++)
    {
      cardPositions[i] = Tile.GetCardSymbol(opponentPlayer.TrapField[i - 1]);
      cardPositions[i + 5] = Tile.GetCardSymbol(opponentPlayer.MonsterField[i - 1]);
      cardPositions[i + 10] = Tile.GetCardSymbol(currentPlayer.MonsterField[i - 1]);
      cardPositions[i + 15] = Tile.GetCardSymbol(currentPlayer.TrapField[i - 1]);
    }

    // Print the grid with fixed player names and deck information
    string row1 = $"==================== {opponentPlayer.Name} ===================";
    string row2 = $"==================== {currentPlayer.Name} ===================";
    string row3 = $"=================================================";
    string space = $"||                                             ||";


    Console.WriteLine("================================= ARENA =================================");
    Console.WriteLine("");
    Console.WriteLine(row1);
    Console.WriteLine(space);
    PrintRow(1, 5, cardPositions, $" (1-5 Spell Card)   || {opponentPlayer.Name} HP: {opponentPlayer.Health}");
    PrintRow(6, 10, cardPositions, $" (1-5 Monster Card) || Deck: [{opponentPlayer.Deck.Cards.Count}] Cards");
    Console.WriteLine(space);
    Console.WriteLine(row3);
    Console.WriteLine(space);
    PrintRow(11, 15, cardPositions, $" (1-5 Monster Card) || {currentPlayer.Name} HP: {currentPlayer.Health}");
    PrintRow(16, 20, cardPositions, $" (1-5 Spell Card)   || Deck: [{currentPlayer.Deck.Cards.Count}] Cards");
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

  internal void PrintYuGiOhGrid(object currentPlayer, object opponentPlayer)
  {
    throw new NotImplementedException();
  }
}
