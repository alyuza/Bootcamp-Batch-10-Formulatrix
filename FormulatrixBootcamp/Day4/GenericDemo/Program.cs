using System;

public class GenericClass<T1, T2>
{
    public void GenericMethod(T1 Brand, T1 Type, T2 Year)
    {
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Year: {Year}");
    }
}

class Program
{
    static void Main()
    {
        GenericClass<string, int> myGenericCLass = new GenericClass<string, int> { };
        myGenericCLass.GenericMethod("Honda", "Vario", 2023);
    }
}