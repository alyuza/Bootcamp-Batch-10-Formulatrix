using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
  private static readonly object _lockObject = new object();
  private static int _counter = 0;

  static void Main()
  {
    // Di tiap thread punya 2 tasks, yaitu DoWork pada task 1 dan task 2.
    // Di dalam DoWork dibikin looping hingga 500 dan input increment ke dalam _counter di mulai dari 0 karena set value di awal = 0

    // Create threads
    Thread thread1 = new Thread(StartTasks);
    Thread thread2 = new Thread(StartTasks);

    // Start threads
    thread1.Start();
    thread2.Start();

    // Wait for threads to complete
    thread1.Join();
    thread2.Join();

    Console.WriteLine($"Final counter value: {_counter}");
  }

  static void StartTasks()
  {
    // Create tasks
    Task task1 = Task.Run(() => DoWork());
    Task task2 = Task.Run(() => DoWork());

    // Wait for tasks to complete
    Task.WaitAll(task1, task2);
  }

  static void DoWork()
  {
    for (int i = 0; i < 500; i++)
    {
      lock (_lockObject)
      {
        _counter++;
      }
    }
  }
}
