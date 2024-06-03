using System;
using System.Collections.Generic;

public class Deck
{
    public List<Card> Cards { get; private set; }
    private Random random;

    public Deck()
    {
        Cards = new List<Card>();
        random = new Random();
    }

    public void AddCard(Card card)
    {
        if (Cards.Count < 10)
        {
            Cards.Add(card);
        }
        else
        {
            throw new InvalidOperationException("Deck can only have 10 cards.");
        }
    }

    public Card DrawCard()
    {
        if (Cards.Count == 0)
        {
            throw new InvalidOperationException("No cards left in the deck.");
        }

        int index = random.Next(Cards.Count);
        Card card = Cards[index];
        Cards.RemoveAt(index);
        return card;
    }
}
