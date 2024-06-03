using System;
using System.Collections.Generic;

public class Player
{
  public List<Card> Hand { get; set; }
  public Card[] MonsterField { get; set; }
  public Card[] TrapField { get; set; }
  public Deck Deck { get; set; }
  public string Name { get; set; }
  public int Health { get; set; }

  public Player(string name, Deck deck)
  {
    Name = name;
    Deck = deck;
    Health = 8000;
    Hand = new List<Card>();
    MonsterField = new Card[5];
    TrapField = new Card[5];
  }

  public void DrawCard()
  {
    if (Deck.Cards.Count > 0)
    {
      Card drawnCard = Deck.Cards[0];
      Hand.Add(drawnCard);
      Deck.Cards.RemoveAt(0);
    }
  }

  public void PlaceCardOnField(int handIndex, int fieldIndex, bool isMonsterField, bool isAttackPosition)
  {
    Card card = Hand[handIndex];
    card.IsInAttackPosition = isAttackPosition;

    if (isMonsterField)
    {
      MonsterField[fieldIndex] = card;
    }
    else
    {
      TrapField[fieldIndex] = card;
    }

    Hand.RemoveAt(handIndex);
  }

  public void RemoveCardFromField(int fieldIndex, bool isMonsterField)
  {
    if (isMonsterField)
    {
      MonsterField[fieldIndex] = null;
    }
    else
    {
      TrapField[fieldIndex] = null;
    }
  }
}
