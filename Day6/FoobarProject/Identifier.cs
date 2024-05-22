using System.Collections.Generic;

public class Identifier
{
  public static Queue<string> Check(int n)
  {
    Queue<string> results = new Queue<string>(); // Create a queue to store the results

    for (int i = 1; i <= n; i++)
    {
      if (i % 3 == 0 && i % 5 == 0)
      {
        results.Enqueue("FooBar"); // Enqueue "FooBar"
      }
      else if (i % 3 == 0)  
      {
        results.Enqueue("Foo"); // Enqueue "Foo"
      }
      else if (i % 5 == 0)
      {
        results.Enqueue("Bar"); // Enqueue "Bar"
      }
      else
      {
        results.Enqueue(i.ToString()); // Enqueue the number itself as a string
      }
    }
    return results;
  }
}
