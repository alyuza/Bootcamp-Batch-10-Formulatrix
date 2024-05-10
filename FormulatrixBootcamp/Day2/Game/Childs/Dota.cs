using Parent;

namespace Childs
{
    public class Dota : Game
    {
        public string gameName = "Dota 2";
        public float gameVersion = 1.3f;
        int gameYear = 2013;

        public Dota(string type, string controller)
        {
            gameType = type;
            gameController = controller;
        }

        public void PrintDota()
        {
            Console.WriteLine($"Game: {gameName}, Game Version: {gameVersion}, Game Year: {gameYear}, {multiplayer}, Game Type: {gameType}, Game Controller: {gameController}");
        }
    }
}