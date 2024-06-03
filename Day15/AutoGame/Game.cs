using System;
using System.Threading.Tasks;

namespace When
{
    public class Game
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public bool IsGameOver { get; private set; }

        public Game(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
            IsGameOver = false;
        }

        public async Task PlayTurn()
        {
            if (!IsGameOver)
            {
                var attack1 = Task.Run(() => player1.Attack(player2));
                var attack2 = Task.Run(() => player2.Attack(player1));

                var firstCompletedTask = await Task.WhenAny(attack1, attack2);

                if (firstCompletedTask == attack1)
                {
                    if (player2.Health <= 0)
                    {
                        Console.WriteLine($"{player2.Name} is defeated! {player1.Name} wins!");
                        IsGameOver = true;
                    }
                }
                else if (firstCompletedTask == attack2)
                {
                    if (player1.Health <= 0)
                    {
                        Console.WriteLine($"{player1.Name} is defeated! {player2.Name} wins!");
                        IsGameOver = true;
                    }
                }

                if (!IsGameOver)
                {
                    if (player1.Health <= 0)
                    {
                        Console.WriteLine($"{player1.Name} is defeated! {player2.Name} wins!");
                        IsGameOver = true;
                    }
                    else if (player2.Health <= 0)
                    {
                        Console.WriteLine($"{player2.Name} is defeated! {player1.Name} wins!");
                        IsGameOver = true;
                    }
                }
            }
        }
    }
}