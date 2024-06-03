```mermaid
classDiagram

class Tile {
    + InitializeCardPositions() : Dictionary<int, string>
    + GetCardSymbol(Card) : string
}

class DisplayManager {
    - player1 : Player
    - player2 : Player
    + DisplayManager(Player, Player)
    + RefreshDisplay() : void
    + ShowState(Player, Player) : void
    + PrintYuGiOhGrid() : void
    + PrintRow(int, int, Dictionary<int, string>, string) : void
}

class Game {
    - player1 : Player
    - player2 : Player
    - isPlayer1Turn : bool
    - displayManager : DisplayManager
    - Actions : Actions
    + Game(Player, Player)
    + StartGame() : void
}

class Actions {
    - displayManager : DisplayManager
    + Actions(DisplayManager)
    + PlaceCardOnField(Player) : void
    + Attack(Player, Player) : void
    + ActivateTrap(Player) : void
}

class Card {
    + Name : string
    + Attack : int
    + Defense : int
    + IsInAttackPosition : bool
    + CardType : CardType
    + AttackChance : int
    + Card(string, int, int, CardType, int)
    + ToString() : string
}

class Deck {
    + Cards : List<Card>
    + random : Random
    + Deck()
    + AddCard(Card) : void
    + DrawCard() : Card
}

class Player {
    + Hand : List<Card>
    + MonsterField : Card[]
    + TrapField : Card[]
    + Deck : Deck
    + Name : string
    + Health : int
    + Player(string, Deck)
    + DrawCard() : void
    + PlaceCardOnField(int, int, bool, bool) : void
    + RemoveCardFromField(int, bool) : void
}

class TrapCard {
    TrapCard(string)
}

TrapCard --|> Card : Inheritance
Player -- Deck : Aggregation
Player -- Card : Association
Player -- DisplayManager : Association
DisplayManager -- Tile : Dependency
Game -- Player : Association
Game -- DisplayManager : Association
Game -- Actions : Association
Actions -- DisplayManager : Association
Deck -- Card : Association
```mermaid