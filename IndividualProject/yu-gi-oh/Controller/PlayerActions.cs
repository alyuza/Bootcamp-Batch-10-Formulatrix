using System;

public class PlayerActions
{
  private DisplayManager displayManager;

  public PlayerActions(DisplayManager dm)
  {
    displayManager = dm;
  }

  public void PlaceCardOnField(Player player)
  {
    Console.WriteLine($"{player.Name}, choose a card from your hand to place on the field: ");
    int handIndex = int.Parse(Console.ReadLine()) - 1;
    // displayManager.RefreshDisplay();

    if (handIndex == -1 || handIndex < 0 || handIndex >= player.Hand.Count)
    {
      return;
    }

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
        // displayManager.RefreshDisplay();
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
        // displayManager.RefreshDisplay();
      }
    }

    Console.WriteLine("Place in attack position? (true/false): ");
    bool isAttackPosition = bool.Parse(Console.ReadLine());
    // displayManager.RefreshDisplay();

    player.PlaceCardOnField(handIndex, fieldIndex, isMonsterField, isAttackPosition);
  }

  public void Attack(Player currentPlayer, Player opponentPlayer)
  {
    while (true)
    {
      // displayManager.RefreshDisplay();
      Console.WriteLine($"{currentPlayer.Name}, choose a monster to attack with (1-5, or 0 to skip): ");
      int attackerIndex = int.Parse(Console.ReadLine()) - 1;
      // displayManager.RefreshDisplay();

      if (attackerIndex == -1 || attackerIndex < 0 || attackerIndex >= currentPlayer.MonsterField.Length)
      {
        break;
      }

      if (currentPlayer.MonsterField[attackerIndex].AttackChance <= 0)
      {
        Console.WriteLine("This monster has already attacked.");
        continue;
      }

      Console.WriteLine($"Choose an opponent monster to attack (1-5): ");
      int defenderIndex = int.Parse(Console.ReadLine()) - 1;
      // displayManager.RefreshDisplay();

      if (defenderIndex == -1 || defenderIndex < 0 || defenderIndex >= opponentPlayer.MonsterField.Length)
      {
        Console.WriteLine("Invalid target.");
        continue;
      }

      Card attackingCard = currentPlayer.MonsterField[attackerIndex];
      Card defendingCard = opponentPlayer.MonsterField[defenderIndex];

      if (defendingCard == null)
      {
        Console.WriteLine("Cannot attack directly while there are cards on the opponent's field.");
        continue;
      }

      if (attackingCard.Attack > defendingCard.Attack)
      {
        // Attacker destroys defender
        opponentPlayer.RemoveCardFromField(defenderIndex, true);
        Console.WriteLine($"{currentPlayer.Name}'s {attackingCard.Name} destroys {opponentPlayer.Name}'s {defendingCard.Name}!");
      }
      else if (attackingCard.Attack < defendingCard.Defense)
      {
        // Attacker is destroyed
        currentPlayer.RemoveCardFromField(attackerIndex, true);
        Console.WriteLine($"{currentPlayer.Name}'s {attackingCard.Name} is destroyed by {opponentPlayer.Name}'s {defendingCard.Name}!");
      }
      else
      {
        // Draw
        currentPlayer.RemoveCardFromField(attackerIndex, true);
        opponentPlayer.RemoveCardFromField(defenderIndex, true);
        Console.WriteLine($"{currentPlayer.Name}'s {attackingCard.Name} and {opponentPlayer.Name}'s {defendingCard.Name} destroyed!");
      }

      // Move this line before removing the card
      attackingCard.AttackChance = 0;
      currentPlayer.RemoveCardFromField(attackerIndex, true);
      break;
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
}
