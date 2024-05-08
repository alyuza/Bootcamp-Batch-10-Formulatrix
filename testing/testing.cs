class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i < 10; i++)
        {
            sb.Append("Data" + i);
        }
        string result = sb.ToString();
        Console.WriteLine(result);

        result = "Monalisa";
        Console.WriteLine(result);
    }
}
