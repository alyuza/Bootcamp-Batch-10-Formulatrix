using Parent;

namespace Childs
{
    public class Valorant : Game
    {
        public string gameName = "Valorant";
        public float gameVersion = 5.7f;
        int gameYear = 2017;

        public Valorant(string type, string controller)
        {
            gameType = type;
            gameController = controller;
        }
        public void PrintValorant()
        {
            Console.WriteLine($"Game: {gameName}, Game Version: {gameVersion}, Game Year: {gameYear}, {multiplayer}, Game Type: {gameType}, Game Controller: {gameController}");
        }
    }
}