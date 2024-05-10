class Car
{
    public virtual void CarSpecification(string detail)
    {
        Console.WriteLine($"Car color is {detail} brown");
    }
}

class Honda : Car
{
    public override void CarSpecification(string detail)
    {
        Console.WriteLine($"Car color is BLACK overriding");
    }
}

class Program
{
    static void Main()
    {
        //Overloading
        Car car = new Car();
        car.CarSpecification("light");

        //Overriding
        Honda honda = new Honda();
        honda.CarSpecification("dark");
    }
}