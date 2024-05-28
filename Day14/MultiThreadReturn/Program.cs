using System.Threading;


class Program
{
  static void Main()
  {
    Thread thread1 = new(BlueArchiveWelcome);
    Thread thread2 = new(BlueArchiveMenu);
    Thread thread3 = new(BlueArchiveUpdater);
    Maths maths = new Maths();
    Thread thread4 = new Thread(() => BlueArchiveID(maths));

    thread3.IsBackground = true;
    thread1.Start();
    thread2.Start();
    thread3.Start();
    thread3.Join(); //TO NEGATE IS BACKGROUND TRUE! to wait background to finish actually
    thread4.Start();
  }

  public static void BlueArchiveWelcome()
  {
    Console.WriteLine($"Welcome, Sensei!\n");
  }

  public static void BlueArchiveMenu()
  {
    Console.WriteLine("Welcome to the menu!\n");
  }
  public static void BlueArchiveUpdater()
  {
    string[] loadingFrames = { "|", "/", "-", "\\" };
    int currentFrame = 0;

    for (int i = 0; i < 50; i++)
    {
      System.Console.Write($"\rUpdating: Loading{loadingFrames[currentFrame]}");
      currentFrame = (currentFrame + 1) % loadingFrames.Length;
      Thread.Sleep(100);
    }
    System.Console.WriteLine("\nUpdate done!");
  }

  public static void BlueArchiveID(Maths maths)
  {
    System.Console.WriteLine("\nInput ID: ");
    int input = Int32.Parse(Console.ReadLine());
    int result = maths.Login(input);
    System.Console.WriteLine($"\nYour ID: {result}-UID");
  }
}

class Maths()
{
  public int Login(int x)
  {
    return x;
  }
}