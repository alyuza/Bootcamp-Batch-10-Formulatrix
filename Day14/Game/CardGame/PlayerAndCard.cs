using System;
using System.Collections.Generic;

namespace CardGame
{
  public class Player
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Card> Deck { get; set; }
    public Player(string name)
    {
      Name = name;
      Health = 100;
      Deck = new List<Card>();
    }

    public void Attack(Player opponent, Card card)
    {
      opponent.Health -= card.AttackPoints;
      Console.WriteLine($"{Name} attacks {opponent.Name} with {card.Name},  dealing {card.AttackPoints} damage. {opponent.Name}'s health is now {opponent.Health}.");
    }
  }

  public class Card
  {
    public string Name { get; set; }
    public int AttackPoints { get; set; }

    public Card(string name, int attackPoints)
    {
      Name = name;
      AttackPoints = attackPoints;
    }
  }
}
