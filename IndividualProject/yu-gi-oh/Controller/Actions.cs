using System;
using System.ComponentModel;

public class PlayerActions
{
  private DisplayManager displayManager;
  private int turnCounter;

  public PlayerActions(DisplayManager dm)
  {
    displayManager = dm;
    turnCounter = 1;
  }

  public void NextTurn()
  {
    turnCounter++;
  }

  public void PlaceCardOnField(Player player)
  {
    int handIndex;

    do
    {
      Console.WriteLine($"{player.Name}, choose a card from your hand to place on the field: ");
      handIndex = int.Parse(Console.ReadLine()) - 1;

      if (handIndex < 0 || handIndex >= player.Hand.Count)
      {
        Console.WriteLine("Invalid hand index. Please enter a valid index.");
      }
    } while (handIndex < 0 || handIndex >= player.Hand.Count);

    Card card = player.Hand[handIndex];
    bool isMonsterField = card.CardType == CardType.Monster;
    int fieldIndex = 0;
    if (isMonsterField)
    {
      if (player.MonsterField[0] == null)
      {
        fieldIndex = 0;
      }
      else
      {
        Console.WriteLine("Choose a field index (1-5): ");
        fieldIndex = int.Parse(Console.ReadLine()) - 1;
      }
    }
    else
    {
      if (player.TrapField[0] == null)
      {
        fieldIndex = 0;
      }
      else
      {
        Console.WriteLine("Choose a field index (1-5): ");
        fieldIndex = int.Parse(Console.ReadLine()) - 1;
      }
    }

    while (true)
    {
      Console.WriteLine("Place in attack position? (true/false): ");
      string input = Console.ReadLine();

      if (bool.TryParse(input, out bool isAttackPosition))
      {
        player.PlaceCardOnField(handIndex, fieldIndex, isMonsterField, isAttackPosition);
        break;
      }
      else
      {
        Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
      }
    }
  }

  public void Attack(Player currentPlayer, Player opponentPlayer)
  {
    while (true)
    {
      // step 1
      Console.WriteLine($"{currentPlayer.Name}, choose a monster to attack with (1-5, write 0 to skip, or 9 to refresh): ");
      if (!int.TryParse(Console.ReadLine(), out int attackerIndex))
      {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
      }

      if (attackerIndex == 9)
      {
        RefreshDisplay(currentPlayer, opponentPlayer);
        continue;
      }
      else if (attackerIndex == 0) // Player chose to skip
      {
        break;
      }

      attackerIndex--; // Adjust index to match array indexing

      if (attackerIndex < 0 || attackerIndex >= currentPlayer.MonsterField.Length || currentPlayer.MonsterField[attackerIndex] == null)
      {
        Console.WriteLine("Invalid choice, please choose a valid monster.");
        continue;
      }

      if (currentPlayer.MonsterField[attackerIndex].AttackChance <= 0)
      {
        Console.WriteLine("This monster has already attacked.");
        continue;
      }

      // step 2
      Console.WriteLine("Choose an opponent monster to attack (1-5): ");
      if (!int.TryParse(Console.ReadLine(), out int defenderIndex))
      {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
      }

      defenderIndex--; // Adjust index to match array indexing

      if (defenderIndex < 0 || defenderIndex >= opponentPlayer.MonsterField.Length)
      {
        Console.WriteLine("Invalid target.");
        continue;
      }

      // attack phase
      Card attackingCard = currentPlayer.MonsterField[attackerIndex];
      Card defendingCard = opponentPlayer.MonsterField[defenderIndex];

      if (defendingCard == null)
      {
        opponentPlayer.Health -= attackingCard.Attack;
        Console.WriteLine($"{currentPlayer.Name}'s {attackingCard.Name} attacks directly, reducing {opponentPlayer.Name}'s HP by {attackingCard.Attack}!");
        attackingCard.AttackChance = 0;
      }
      else if (attackingCard.Attack > defendingCard.Attack)
      {
        // attacker destroys defender
        opponentPlayer.RemoveCardFromField(defenderIndex, true);
        Console.WriteLine($"{currentPlayer.Name}'s {attackingCard.Name} destroys {opponentPlayer.Name}'s {defendingCard.Name}!");
        opponentPlayer.Health -= (attackingCard.Attack - defendingCard.Attack);
        Console.WriteLine($"{opponentPlayer.Name} loses {attackingCard.Attack - defendingCard.Attack} HP!");
      }
      else if (attackingCard.Attack < defendingCard.Attack)
      {
        // attacker is destroyed
        currentPlayer.RemoveCardFromField(attackerIndex, true);
        Console.WriteLine($"{currentPlayer.Name}'s {attackingCard.Name} is destroyed by {opponentPlayer.Name}'s {defendingCard.Name}!");
        currentPlayer.Health -= (defendingCard.Attack - attackingCard.Attack);
        Console.WriteLine($"{currentPlayer.Name} loses {defendingCard.Attack - attackingCard.Attack} HP!");
      }
      else
      {
        // draw
        currentPlayer.RemoveCardFromField(attackerIndex, true);
        opponentPlayer.RemoveCardFromField(defenderIndex, true);
        Console.WriteLine($"{currentPlayer.Name}'s {attackingCard.Name} and {opponentPlayer.Name}'s {defendingCard.Name} destroyed!");
      }

      attackingCard.AttackChance = 0;
    }

  }

  public void ActivateTrap(Player opponentPlayer)
  {
    for (int i = 0; i < opponentPlayer.TrapField.Length; i++)
    {
      if (opponentPlayer.TrapField[i] != null)
      {
        Console.WriteLine($"{opponentPlayer.Name} activates {opponentPlayer.TrapField[i].Name}, ending the turn.");
        opponentPlayer.RemoveCardFromField(i, false);
        break;
      }
    }
  }

  public void RefreshDisplay(Player currentPlayer, Player opponentPlayer)
  {
    Console.Clear();
    displayManager.PrintYuGiOhGrid(currentPlayer, opponentPlayer);
    displayManager.ShowState(currentPlayer, opponentPlayer);
  }
}