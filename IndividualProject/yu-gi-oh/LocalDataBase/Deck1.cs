using System;

public class Deck1 : Deck
{
  public Deck1() : base()
  {
    try
    {
      AddCard(new Card("Blue-Eyes White Dragon", 3000, 2500, CardType.Monster));
      AddCard(new Card("Dark Magician", 2500, 2100, CardType.Monster));
      AddCard(new Card("Summoned Skull", 2500, 1200, CardType.Monster));
      AddCard(new Card("Red-Eyes Black Dragon", 2400, 2000, CardType.Monster));
      AddCard(new Card("Buster Blader", 2600, 2300, CardType.Monster));
      AddCard(new Card("Celtic Guardian", 1400, 1200, CardType.Monster));
      AddCard(new Card("Gaia The Fierce Knight", 2300, 2100, CardType.Monster));
      AddCard(new Card("Mystical Elf", 800, 2000, CardType.Monster));
      AddCard(new TrapCard("False Trap"));
      AddCard(new TrapCard("False Trap"));
    }
    catch (InvalidOperationException ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
}
