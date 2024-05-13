// Delegate Material 1
// public delegate void MyDelegate();
// public class Program
// {
//     static void Print()
//     {
//         Console.Write("Selamat Pagi");
//     }

//     static void Run()
//     {
//         Console.Write(" Bu Guru!");
//     }

//     static void Main()
//     {
//         MyDelegate my = new MyDelegate(Print);
//         my += Run;
//         my();
//     }
// }

// Delegate Material 2
// public delegate void MyDelegate(string word);
// public class Program
// {
//     public static void Hey(string word)
//     {
//         Console.WriteLine($"Hey {word}");
//     }

//     public static void Yo(string word)
//     {
//         Console.WriteLine($"Yo {word}");
//     }

//     static void Main()
//     {
//         MyDelegate heyo = new MyDelegate(Hey);
//         heyo += Yo;
//         heyo("test");
//     }
// }

// Delegate Material 3
// using System.Reflection;

// namespace DelegateMaterial3
// {
//     public delegate int MyDelegate(int a, int b);

//     class Subscriber
//     {
//         public int Add(int a, int b)
//         {
//             return a + b;
//         }
//         public int Multiply(int a, int b)
//         {
//             return a * b;
//         }
//     }
//     public class Program
//     {
//         static void Main()
//         {
//             // ============== case 1 ===============
//             // Subscriber subscriber = new Subscriber();
//             // MyDelegate delegation = subscriber.Add;
//             // delegation += subscriber.Multiply;
//             // Console.WriteLine(delegation?.Invoke(5, 5));


//             // ============== case 2 ================
//             Subscriber subscriber = new Subscriber();
//             MyDelegate delegation = subscriber.Add;
//             delegation += subscriber.Multiply;

//             float result = delegation(5, 5);

//             Delegate[] dell = delegation.GetInvocationList();
//             foreach (Delegate dg in dell)
//             {
//                 Console.WriteLine(dg.GetMethodInfo().Name + ":" + ((MyDelegate)dg).Invoke(5, 5));
//             }

//         }
//     }
// }

// Event Handler Material 1 - price change
// using System;
// public delegate void PriceChangedEventHandler(object sender, PriceChangedEventArgs e);

// public class PriceChangedEventArgs : EventArgs
// {
//     public decimal OldPrice { get; set; }
//     public decimal NewPrice { get; set; }
// }

// public class Product
// {
//     private decimal price;

//     public event PriceChangedEventHandler PriceChanged;

//     public decimal Price
//     {
//         get { return price; }
//         set
//         {
//             if (price != value)
//             {
//                 PriceChangedEventArgs args = new PriceChangedEventArgs
//                 {
//                     OldPrice = price,
//                     NewPrice = value
//                 };

//                 price = value;
//                 OnPriceChanged(args);
//             }
//         }
//     }

//     protected virtual void OnPriceChanged(PriceChangedEventArgs e)
//     {
//         if (PriceChanged != null)
//         {
//             PriceChanged(this, e);
//         }
//     }
// }

// public class Customer
// {
//     public void HandlePriceChanged(object sender, PriceChangedEventArgs e)
//     {
//         Console.WriteLine($"Old price: {e.OldPrice:C}");
//         Console.WriteLine($"New price: {e.NewPrice:C}");
//     }
// }

// public static class Program
// {
//     public static void Main()
//     {
//         Product product = new Product();
//         Customer customer = new Customer();

//         product.PriceChanged += customer.HandlePriceChanged;

//         Console.WriteLine("Enter a new price:");
//         string input = Console.ReadLine();
//         decimal newPrice = decimal.Parse(input);
//         product.Price = newPrice;
//     }
// }

// Event Handler Material 2 - Degree 
// public delegate void DegreeEventHandler(object sender, EventArgs e);
// public class Robot
// {
//     public float Degree;
//     public event DegreeEventHandler DegreeHandler;

//     // Modify DegreeInput to take the degree as input
//     public void DegreeInput(float degree)
//     {
//         Degree = degree; // Assign the input degree to the Degree property
//         if (Degree > 30)
//         {
//             Console.WriteLine("Give the robot some ice cream!");
//         }
//         else if (Degree < 20)
//         {
//             Console.WriteLine("Give the robot some hot tea!");
//         }
//         else
//         {
//             Console.WriteLine("No action needed.");
//         }
//         DegreeHandler?.Invoke(this, EventArgs.Empty); // Invoke the event
//     }
// }
// public class FinalMessage
// {
//     public void HandleMessage(object sender, EventArgs e)
//     {
//         Console.WriteLine("Thank you for input the degree information!");
//     }
// }
// public static class Program
// {
//     public static void Main()
//     {
//         FinalMessage message = new FinalMessage();
//         Robot button = new Robot();
//         button.DegreeHandler += message.HandleMessage;

//         Console.WriteLine("Input the example Degree: ");
//         if (float.TryParse(Console.ReadLine(), out float degree)) // Read and parse the degree input
//         {
//             button.DegreeInput(degree); // Pass the degree input to the DegreeInput method
//         }
//         else
//         {
//             Console.WriteLine("Invalid input. Please enter a valid number for the degree."); // error handler when the input is not a number
//         }
//     }
// }

// Try Catch (Exceptions) - Format Exceptions
// class Program
// {
//     static void Main()
//     {
//         string A = "Nana26";
//         try
//         {
//             int result = int.Parse(A);
//         }
//         catch (Exception ex)
//         {
//             Console.Write(ex);
//         }
//     }
// }

// Try Catch (Exceptions) - Format Exceptions 2
// public class Program
// {
//     public static void ExceptionMaker()
//     {
//         // Case 1: IndexOutOfRangeException
//         int[] numbers = new int[3];
//         Console.WriteLine(numbers[3]);

//         // Case 2: DivideByZeroException
//         int a = 10;
//         int b = 0;
//         Console.WriteLine(a / b);
//     }

//     static void Main()
//     {
//         try
//         {
//             ExceptionMaker();
//         }
//         catch (IndexOutOfRangeException ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//         catch (DivideByZeroException ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }

// 
class Human
{
    public int Balance { get; private set; } // Pascal case
    public string Name { get; set; }
    public void SetBalance(int x)
    {
        Balance = x;
    }
    public void PrintBalance()
    {
        Console.WriteLine(Balance);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Human hm = new Human();
            hm.SetBalance(3000000);
            hm.PrintBalance();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}