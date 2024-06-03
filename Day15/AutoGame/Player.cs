using System;

namespace When
{
  public class Player
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPoint { get; set; }

    public Player(string name)
    {
      Name = name;
      Health = 100;
      AttackPoint = 20;
    }

    public void Attack(Player opponent)
    {
      opponent.Health -= AttackPoint;
      Console.WriteLine($"{Name} attacks {opponent.Name} dealing {AttackPoint} damage. {opponent.Name}'s Health is now {opponent.Health}.");
    }
  }
}
