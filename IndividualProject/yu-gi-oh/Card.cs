public class Card
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool IsInAttackPosition { get; set; }
    public CardType CardType { get; set; }
    public int AttackChance { get; set; }

    public Card(string name, int attack, int defense, CardType cardType, int attackChance = 1)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        IsInAttackPosition = true;
        CardType = cardType;
        AttackChance = attackChance;
    }

    public override string ToString()
    {
        return $"{Name} (ATK: {Attack}, DEF: {Defense}, Type: {CardType}, Attack Chance: {AttackChance})";
    }
}
