// Material 1 (ref, in and out)
// | ref is used to state that the parameter passed may be modified by the method.
// | in is used to state that the parameter passed cannot be modified by the method.
// | out is used to state that the parameter passed must be modified by the method.

// using System;

// class Program
// {
//     static void Main()
//     {
//         int refParameter = 7;
//         int inParameter = 23;
//         int outParameter;

//         ExampleMethod(ref refParameter, in inParameter, out outParameter);
//         Console.WriteLine(refParameter);
//         Console.WriteLine(inParameter);
//         Console.WriteLine(outParameter);

//     }

//     public static void ExampleMethod(ref int refParameter, in int inParameter, out int outParameter)
//     {
//         refParameter += 10;
//         inParameter;
//         outParameter = 20;
//     }
// }

// Material 2 (enum)
// using System;

// public enum BasketballPlayer
// {
//     KobeBryant = 24,
//     LebronJames = 23
// }

// public class Program
// {
//     static void Main()
//     {
//         BasketballPlayer player = BasketballPlayer.KobeBryant;
//         int number = (int)BasketballPlayer.KobeBryant;
//         Console.WriteLine($"Basketball Player's Name: {player}");
//         Console.WriteLine($"Basketball Player's Number: {number}");
//     }
// }

//Material 3 (params)

class Calculator
{
    public int Add(params int[] numbers)
    {
        int sum = 0;
        foreach (int i in numbers)
        {
            sum += i;
        }
        return sum;
    }
}

class StringCalculator
{
    public int Add(params string[] numbersString)
    {
        int sum = 0;
        foreach (string i in numbersString)
        {
            int number = int.Parse(i);
            sum += number;
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new();
        int result = calc.Add(1, 2, 3, 4, 5);
        Console.WriteLine(result);

        StringCalculator calcString = new();
        int result2 = calcString.Add("2", "5");
        Console.WriteLine(result2);
    }
}