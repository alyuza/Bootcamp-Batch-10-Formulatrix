using System.Diagnostics.Contracts;

namespace PokerGame;

public class Evaluator
{
    public Dictionary<Player, int> cardPoints = new();
    
    public void DetermineWinner()
    {
        var listCardPoints = cardPoints.ToList();
        listCardPoints.Sort((a, b) => b.Value.CompareTo(a.Value));
        var highestPoints = listCardPoints[0];
        var potentialWinner = listCardPoints.Where(item => item.Value == highestPoints.Value).ToList();
        if (potentialWinner.Count == 1)
        {
            var winner = listCardPoints[0];
        }
    }

    public void Evaluate(Dictionary<Player, List<Card>> combinedCard)
    {
        
        cardPoints = new Dictionary<Player, int>();
        Dictionary<Func<List<Card>, bool>, CardCombinator> cardCombinations = new()
        {
            { IsAnyStraightFlush, CardCombinator.StraightFlush },
            { IsAnyFlush, CardCombinator.Flush },
            { IsAnyStraight, CardCombinator.Straight },
            { IsAnyFourOfAkind, CardCombinator.FourOfAKind },
            { IsAnyFullHouse, CardCombinator.FullHouse },
            { IsAnyThreeOfKind, CardCombinator.ThreeOfAKind },
            { IsAnyTwoPair, CardCombinator.TwoPair },
            { IsAnyPair, CardCombinator.Pair },
        };
        foreach (var card in combinedCard)
        {
            int points = (int)CardCombinator.HighCard;
            foreach (var combinator in cardCombinations)
            {
                if (combinator.Key(card.Value))
                {
                    points = (int)combinator.Value;
                    break;
                }
            }

            if (!card.Key.GetIsFolded())
            {
                cardPoints.TryAdd(card.Key, points);
            }
        }
    }

    public bool IsAnyFlush(List<Card> combinedCard)
    {
        return combinedCard.GroupBy(card => card.Suit).Count(group => group.Count() >= 5) == 1;
    }

    public bool IsAnyFullHouse(List<Card> combinedCard)
    {
        return IsAnyThreeOfKind(combinedCard) && IsAnyPair(combinedCard);
    }

    public bool IsAnyFourOfAkind(List<Card> combinedCard)
    {
        return combinedCard.GroupBy(card => card.Number).Any(group => group.Count() == 4);
    }


    public bool IsAnyStraight(List<Card> combinedCard)
    {
        combinedCard.Sort((a, b) => b.Number.CompareTo(a.Number));
        var distractedCombinedCard = combinedCard.Distinct().ToList();

        var middleStraight = distractedCombinedCard[3].Number - distractedCombinedCard[1].Number == -2 &&
                             distractedCombinedCard[3].Number - distractedCombinedCard[5].Number == 2 &&
                             distractedCombinedCard[3].Number - distractedCombinedCard[2].Number == -1 &&
                             distractedCombinedCard[3].Number - distractedCombinedCard[4].Number == 1;
        var highStraight = distractedCombinedCard[2].Number - distractedCombinedCard[0].Number == -2 &&
                           distractedCombinedCard[2].Number - distractedCombinedCard[4].Number == 2 &&
                           distractedCombinedCard[2].Number - distractedCombinedCard[1].Number == -1 &&
                           distractedCombinedCard[2].Number - distractedCombinedCard[3].Number == 1;
        var lowStraight = distractedCombinedCard[4].Number - distractedCombinedCard[2].Number == -2 &&
                          distractedCombinedCard[4].Number - distractedCombinedCard[6].Number == 2 &&
                          distractedCombinedCard[4].Number - distractedCombinedCard[3].Number == -1 &&
                          distractedCombinedCard[4].Number - distractedCombinedCard[5].Number == 1;

        if (middleStraight || highStraight || lowStraight)
        {
            return true;
        }

        return false;
    }

    public bool IsAnyStraightFlush(List<Card> combinedCard)
    {
        return IsAnyStraight(combinedCard) && IsAnyFlush(combinedCard);
    }

    public bool IsAnyPair(List<Card> combinedCard)
    {
        return combinedCard.GroupBy(card => card.Number).Count(group => group.Count() == 2) == 1;
    }

    public bool IsAnyTwoPair(List<Card> combinedCard)
    {
        return combinedCard.GroupBy(card => card.Number).Count(group => group.Count() == 2) == 2;
    }

    public bool IsAnyThreeOfKind(List<Card> combinedCard)
    {
        return combinedCard.GroupBy(card => card.Number).Any(group => group.Count() == 3);
    }
}