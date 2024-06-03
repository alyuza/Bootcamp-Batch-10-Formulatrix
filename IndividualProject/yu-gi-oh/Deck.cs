using System;
using System.Threading;

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

    public void Shuffle()
    {
        string[] animation = { "\\", "|", "-", "/" };
        int animationIndex = 0;

        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Card value = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = value;

            Console.Write($"\rSHUFFLING DECK {animation[animationIndex]}"); // animation
            animationIndex = (animationIndex + 1) % animation.Length;
            Thread.Sleep(300);
        }
    }
}
