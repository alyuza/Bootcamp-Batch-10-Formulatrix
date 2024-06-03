namespace PokerGame;

public class GameController
{
    private Stages _currentStage = Stages.PreFlop;
    public Stages CurrentStages => _currentStage;
    private int _smallBlindIndex;
    private int _bigBlindIndex;
    private int _currentTurnIndex;
    private int _playerTurn;
    private int _previousBets;
    private int _totalBet;
    public readonly int smallBlind = 5;
    public readonly int BigBlind = 10;


    private Deck? _deck = new Deck();
    private Evaluator _evaluator = new Evaluator();

    private List<Card> _tableCard = new();
    private Dictionary<Player, List<Card>> _combinedCard = new();
    public Dictionary<Player, List<Card>?> _playerHandCard = new();
    public readonly List<Player> players = new();

    public GameController()
    {
        AddPlayerToList();
        foreach (Player player in players)
        {
            _playerHandCard[player] = new List<Card>();
        }

        _smallBlindIndex = 0;
        _bigBlindIndex = 1;
        _currentTurnIndex = 2;
        _playerTurn = _currentTurnIndex;
        StartStages();
        DealPlayerCard(players);
    }

    public void CombineCard()
    {
        foreach (var player in _playerHandCard.Keys)
        {
            List<Card> combinedCards = new List<Card>(_playerHandCard[player]);
            combinedCards.AddRange(_tableCard);
            _combinedCard.Add(player, combinedCards);
        }
    }

    public void DetermineWinner()
    {
        var playerHigestPoints = _evaluator.cardPoints.Values.Max();
        var highestPoints = _evaluator.cardPoints.Where(point => point.Value == playerHigestPoints).ToList();
        foreach (var card in _combinedCard)
        {
            Console.WriteLine($"\nList Combined card of {card.Key.GetName()}\n");
            foreach (var cardDetail in card.Value)
            {
                Console.WriteLine($"{(int)cardDetail.Number}{cardDetail.suitNotation}");
            }
        }

        if (highestPoints.Count == 1)
        {
            Console.WriteLine($"\n Winner is = {highestPoints[0].Key.GetName()} {(CardCombinator)playerHigestPoints}");
        }
        if (highestPoints.Count >= 1)
        {
            var sortedCard = _combinedCard.OrderByDescending(kvp =>
            {
                var totalValue = kvp.Value.Sum(card => (int)card.Number); // not all condition work
                return totalValue;
            }).ToList();
            
            foreach (var card in sortedCard)
            {
                foreach (var value in card.Value)
                {
                    Console.WriteLine($"{card.Key.GetName()} : {value.Number}");
                }
            }

            Console.WriteLine($"\nWinner of game = {sortedCard.First().Key.GetName()} {(CardCombinator)playerHigestPoints}");
        }

        foreach (var item in _evaluator.cardPoints)
        {
            Console.WriteLine($"\n{item.Key.GetName()} points : {(CardCombinator)item.Value} ");
        }
    }
    
    public void ShowDown()
    {
        CombineCard();
        _evaluator.Evaluate(_combinedCard);
        DetermineWinner();
        
    }

    public void StartStages()
    {
        players[_smallBlindIndex].Bet(smallBlind);
        _totalBet += smallBlind;
        players[_bigBlindIndex].Bet(BigBlind);
        _totalBet += BigBlind;
    }

    public void RotateBlind() // todo rotate blind still got error
    {
        _smallBlindIndex = (_smallBlindIndex + 1) % players.Count;
        _bigBlindIndex = (_bigBlindIndex + 1) % players.Count;
        _currentTurnIndex = (_currentTurnIndex + 1) % players.Count;
    }


    private void AddPlayerToList()
    {
        Player player1 = new Player("Ariston", 1);
        Player player2 = new Player("Rais", 2);
        Player player3 = new Player("Zidane", 3);
        Player player4 = new Player("Ahmad", 4);

        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
    }


    public void DealPlayerCard(List<Player> players)
    {
        foreach (Player player in players)
        {
            for (int i = 0; i < 2; i++)
            {
                Card holeCard = _deck.listCardDeck[_deck.listCardDeck.Count - 1];
                AddHoleCard(player, holeCard);
                _deck.listCardDeck.RemoveAt(_deck.listCardDeck.Count - 1);
            }
        }
    }

    public List<Card> GetTableCards()
    {
        return _tableCard;
    }

    private void AddTableCard()
    {
        Card holeCard = _deck.listCardDeck[_deck.listCardDeck.Count - 1];
        _tableCard.Add(holeCard);
        _deck.listCardDeck.RemoveAt(_deck.listCardDeck.Count - 1);
    }

    public void ResetRound()
    {
        foreach (var player in players)
        {
            player.SetIsFolded(false);
        }

        _playerHandCard.Clear();
        _combinedCard.Clear();
        _tableCard.Clear();
        _deck = new Deck();
        RotateBlind();
        _currentStage = Stages.PreFlop;
        DealPlayerCard(players);
        Console.Clear();
    }

    public void DealTableCard()
    {
        if (_tableCard.Count <= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                AddTableCard();
            }
        }
        else
        {
            AddTableCard();
        }

        _currentStage++;
    }

    public void AddHoleCard(Player player, Card card)
    {
        if (_playerHandCard.ContainsKey(player))
        {
            _playerHandCard[player].Add(card);
        }
        else
        {
            _playerHandCard[player] = new List<Card> { card };
        }
    }

    public List<Card> GetDeckCard()
    {
        return _deck!.listCardDeck!;
    }

    public List<Player> GetListPlayer()
    {
        return players;
    }

    public List<Card> GetPlayerCard(Player player)
    {
        _playerHandCard.TryGetValue(player, out List<Card> playerCard);
        return playerCard ?? new List<Card>();
    }

    public Player GetCurrentTurn()
    {
        return players[_playerTurn];
    }

    public void NextTurn()
    {
        _playerTurn = (_playerTurn + 1) % players.Count;
        while (players[_playerTurn].GetIsFolded())
        {
            _playerTurn = (_playerTurn + 1) % players.Count;
        }
    }

    public int GetPlayerTurn()
    {
        return _playerTurn;
    }

    public int GetTotalBet()
    {
        return _totalBet;
    }

public void RaiseAction(PlayerAction action, int amount)
    {
        var raise = players[_playerTurn].Raise(amount);
        _totalBet += raise;
        _previousBets = raise;
        NextTurn();
    }


    public void Action(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.Bet:
                var bet = players[_playerTurn].Bet(BigBlind);
                _totalBet += bet;
                _previousBets = bet;
                NextTurn();
                break;
            case PlayerAction.Check:
                NextTurn();
                break;
            case PlayerAction.Call:
                var call = players[_playerTurn].Call(_previousBets);
                _totalBet += _previousBets;
                _previousBets = call;
                NextTurn();
                break;
            case PlayerAction.AllIn:
                var allIn = players[_playerTurn].AllIn();
                _totalBet += allIn;
                _previousBets = allIn;
                NextTurn();
                break;
            case PlayerAction.Fold:
                players[_playerTurn].Fold();
                NextTurn();
                break;
        }
    }
}