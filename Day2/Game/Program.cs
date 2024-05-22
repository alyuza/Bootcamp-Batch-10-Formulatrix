using Childs;
class Program
{
    static void Main()
    {
        Dota dota = new("Moba", "Keyboard and mouse");
        MobileLegend mobileLegend = new("Moba","Keyboard and mouse");
        Valorant valorant = new("FPS","Keyboard and mouse");

        Console.WriteLine("=====================================");
        dota.PrintDota();
        mobileLegend.PrintMobileLegend();
        valorant.PrintValorant();
        Console.WriteLine("=====================================");
    }
}