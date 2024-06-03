using System;

class Program
{
    static void Main()
    {
        // Create decks
        Deck deck1 = new Deck();
        Deck deck2 = new Deck();

        // Create players with their respective decks
        Player player1 = new Player("Player 1", deck1);
        Player player2 = new Player("Player 2", deck2);

        // Create cards
        // Card monster1 = new Card("Dragon", 2000, 1500, CardType.Monster);
        // Card monster2 = new Card("Warrior", 1800, 1300, CardType.Monster);
        // Card trap = new TrapCard("Trap Hole");
        try
        {
            deck1.AddCard(new Card("Blue-Eyes White Dragon", 3000, 2500, CardType.Monster));
            deck1.AddCard(new Card("Dark Magician", 2500, 2100, CardType.Monster));
            deck1.AddCard(new Card("Summoned Skull", 2500, 1200, CardType.Monster));
            deck1.AddCard(new Card("Red-Eyes Black Dragon", 2400, 2000, CardType.Monster));
            deck1.AddCard(new Card("Buster Blader", 2600, 2300, CardType.Monster));
            deck1.AddCard(new Card("Celtic Guardian", 1400, 1200, CardType.Monster));
            deck1.AddCard(new Card("Gaia The Fierce Knight", 2300, 2100, CardType.Monster));
            deck1.AddCard(new Card("Mystical Elf", 800, 2000, CardType.Monster));
            deck1.AddCard(new TrapCard("False Trap"));
            deck1.AddCard(new TrapCard("False Trap"));


            deck2.AddCard(new Card("Exodia the Forbidden One", 1000, 1000, CardType.Monster));
            deck2.AddCard(new Card("Obelisk the Tormentor", 4000, 4000, CardType.Monster));
            deck2.AddCard(new Card("Slifer the Sky Dragon", 3000, 2500, CardType.Monster));
            deck2.AddCard(new Card("The Winged Dragon of Ra", 3000, 2500, CardType.Monster));
            deck2.AddCard(new Card("Dark Magician Girl", 2000, 1700, CardType.Monster));
            deck2.AddCard(new Card("Cyber Dragon", 2100, 1600, CardType.Monster));
            deck2.AddCard(new Card("Kuriboh", 300, 200, CardType.Monster));
            deck2.AddCard(new Card("Time Wizard", 500, 400, CardType.Monster));
            deck2.AddCard(new TrapCard("False Trap"));
            deck2.AddCard(new TrapCard("False Trap"));

        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Game game = new Game(player1, player2);
        game.StartGame();
    }
}
