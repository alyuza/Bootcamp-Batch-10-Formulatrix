using System;

class Cat
{
    public string race;
    public string color;
    public int age;
}

class Sounds
{
    public void Sound1
    {
        Console.WriteLine("Miaawww")
    }
}

class Program
{
    static void Main()
    {
        Cat myCat = new();
        myCat.race = "Siamese";
        myCat.color = "Brown";
        myCat.age = 3;

        Console.WriteLine($"My cat is a {myCat.color} {myCat.race} and is {myCat.age} years old.");
    }
}