using System;

public class Deck2 : Deck
{
  public Deck2() : base()
  {
    try
    {
      AddCard(new Card("Exodia the Forbidden One", 1000, 1000, CardType.Monster));
      AddCard(new Card("Obelisk the Tormentor", 4000, 4000, CardType.Monster));
      AddCard(new Card("Slifer the Sky Dragon", 3000, 2500, CardType.Monster));
      AddCard(new Card("The Winged Dragon of Ra", 3000, 2500, CardType.Monster));
      AddCard(new Card("Dark Magician Girl", 2000, 1700, CardType.Monster));
      AddCard(new Card("Cyber Dragon", 2100, 1600, CardType.Monster));
      AddCard(new Card("Kuriboh", 300, 200, CardType.Monster));
      AddCard(new Card("Time Wizard", 500, 400, CardType.Monster));
      AddCard(new TrapCard("False Trap"));
      AddCard(new TrapCard("False Trap"));
    }
    catch (InvalidOperationException ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
}
