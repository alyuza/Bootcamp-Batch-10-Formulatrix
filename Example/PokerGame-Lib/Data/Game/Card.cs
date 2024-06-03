using System.Diagnostics;

namespace PokerGame;

public class Card
{
    
    public Suit Suit;
    public Number Number;
    public string suitNotation => suitNotations[(int)Suit];
    public int numberNotation  => (int)Number;
    
    public readonly string[] suitNotations = new[]{"♥", "♦", "♠", "♣" };
  
    public Card(Suit suit, Number number)
    {
        this.Suit = suit;
        this.Number = number;
    }
}
public enum Suit { Heart, Diamond, Spades, Club }
public enum Number { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }