class Motorcycle
{
    public string model;
    public string color;
    public int productionYear;
    public double price;
    public Motorcycle(string motorName, string motorColor, int motorYear)
    {
        model = motorName;
        color = motorColor;
        productionYear = motorYear;
    }

    public Pricing(double price)
    {
        totalPrice = price;
    }

    static void Main()
    {
        Motorcycle unit = new("honda", "black", 2000);
        Motorcycle unit2 = new("toyota", "red", 2021);
        Console.WriteLine(unit.price + unit2.price);
    }
}