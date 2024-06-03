using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Player 1's name:");
        string playerName1 = Console.ReadLine();

        Console.WriteLine("Enter Player 2's name:");
        string playerName2 = Console.ReadLine();

        // create decks
        Deck deck1 = new Deck1();
        Deck deck2 = new Deck2();

        // create players with the entered names
        Player player1 = new Player(playerName1, deck1);
        Player player2 = new Player(playerName2, deck2);

        Game game = new Game(player1, player2);
        game.StartGame();
    }
}
