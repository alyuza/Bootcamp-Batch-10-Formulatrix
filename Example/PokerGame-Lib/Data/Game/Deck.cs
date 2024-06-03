namespace PokerGame;

public class Deck
{
    public List<Card>? listCardDeck = new List<Card>();

    public Deck()
    {
        IntializeDeck();
        Shuffle();
    }

    // public List<Card> Cards
    // {
    //     get { return listCardDeck; }
    // }

    public void IntializeDeck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Number number in Enum.GetValues(typeof(Number)))
            {
                listCardDeck.Add(new Card(suit, number));
            }
        }
    }
    public void Shuffle()
    {
        Random random = new Random();
        int n = listCardDeck!.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            Card temp = listCardDeck[i];
            listCardDeck[i] = listCardDeck[j];
            listCardDeck[j] = temp;
        }
    }
}
