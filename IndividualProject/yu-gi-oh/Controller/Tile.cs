using System.Collections.Generic;

public static class Tile
{
    public static Dictionary<int, string> InitializeCardPositions()
    {
        var cardPositions = new Dictionary<int, string>();
        for (int i = 1; i <= 20; i++)
        {
            cardPositions[i] = "[ ]";
        }
        return cardPositions;
    }

    public static string GetCardSymbol(Card card)
    {
        if (card == null)
        {
            return "[ ]";
        }
        else if (card.CardType == CardType.Monster)
        {
            return "[\x1b[33mM\x1b[0m]"; // yellow M
        }
        else
        {
            return "[\x1b[35mT\x1b[0m]"; // purple T
        }
    }
}
