public class Identifier
{
    public static Queue<string> Check(int n)
    {
        Queue<string> results = new Queue<string>(); // create queue to store results value

        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                results.Enqueue("FooBar"); // enqueue "FooBar"
            }
            else if (i % 3 == 0)
            {
                results.Enqueue("Foo");
            }
            else if (i % 5 == 0)
            {
                results.Enqueue("Bar");
            }
            else
            {
                results.Enqueue(i.ToString()); // enqueue the number it self as a string
            }
        }
        return results;
    }
}
