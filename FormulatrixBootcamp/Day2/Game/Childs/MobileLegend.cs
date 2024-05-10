using Parent;

namespace Childs
{
    public class MobileLegend : Game
    {
        public string gameName = "Mobile Legend";
        public float gameVersion = 5.4f;
        int gameYear = 2017;
        public MobileLegend(string type, string controller)
        {
            gameType = type;
            gameController = controller;
        }
        public void PrintMobileLegend()
        {
            Console.WriteLine($"Game: {gameName}, Game Version: {gameVersion}, Game Year: {gameYear}, {multiplayer}, Game Type: {gameType}, Game Controller: {gameController}");
        }
    }
}