// Lambda Expression dan Action Delegate
// using System;

// class Program
// {
//     static void Main()
//     {
//         Action greet = () => // lambda expression / arrow function
//         {
//             Console.WriteLine("Hello");
//         };
//         greet();

//         Action<string> greetWithName = (name) =>
//         {
//             Console.WriteLine($"Hello {name}");
//         };
//         greetWithName("John");
//     }
// }

// Operator Overloading
// public class Box
// {
//     public int Length { get; set; }
//     public int Width { get; set; }
//     public Box(int length, int width)
//     {
//         Length = length;
//         Width = width;
//     }
//     public static Box operator +(Box b1, Box b2)
//     {
//         int totalLength = b1.Length + b2.Length;
//         int totalWidth = b1.Width + b2.Width;
//         Box box = new(totalLength, totalWidth);
//         return box;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Box box1 = new(2, 5);
//         Box box2 = new(2, 10);
//         Box box3 = box1 + box2;
//         Console.WriteLine(box3.Length);
//         Console.WriteLine(box3.Width);
//     }
// }

// =============================PARTIAL===============================
// File MyClass1.cs
public partial class MyClass
{
    public void Method1()
    {
        // Implementasi Method1
    }
}

// File MyClass2.cs
public partial class MyClass
{
    public void Method2()
    {
        // Implementasi Method2
    }
}

// File Program.cs
class Program
{
    static void Main()
    {
        MyClass obj = new MyClass();
        obj.Method1();
        obj.Method2();
    }
}

