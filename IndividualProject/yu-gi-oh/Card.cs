public class Card
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool IsInAttackPosition { get; set; }
    public CardType CardType { get; set; }
    public int AttackChance { get; set; }

    public Card(string name, int attack, int defense, CardType cardType, int attackChance = 1, bool isInAttackPosition = true)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        IsInAttackPosition = isInAttackPosition;
        CardType = cardType;
        AttackChance = attackChance;
    }

    public override string ToString()
    {
        string state = IsInAttackPosition ? "Attack" : "Defense";
        string attackChance = CardType == CardType.Monster ? "1" : "0";
        return $"{Name} (ATK: {Attack}, DEF: {Defense}, Type: {CardType}, Attack Chance: {attackChance}, State: {state})";
    }
}
