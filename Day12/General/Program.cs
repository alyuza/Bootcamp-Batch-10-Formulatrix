class Program
{
  static void Main()
  {
    string result = String.Empty;
    int iteration = 10000;
    for (int i = 0; i < iteration; i++)
    {
      result += "Hello";
      result += "Yuza";
      Console.Write(result);
    }
  }
}