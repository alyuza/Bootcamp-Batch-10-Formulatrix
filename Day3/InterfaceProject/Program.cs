// interface IAirplane //Interface satu
// {
//     void JetSound();
// }
// interface IMachine // Interface dua
// {
//     void MachineBrand();
// }
// interface IPropeller // Interface tiga
// {
//     void PropellerBrand();
// }
// interface IWheel // Interface empat
// {
//     void WheelBrand();
// }

// abstract class Performance
// {
//     public abstract void Speed();
//     public void ProductionYear()
//     {
//         Console.WriteLine("2023");
//     }
// }
// class GarudaAirPlane : Performance, IAirplane, IMachine, IPropeller, IWheel // Multiple Interface
// {
//     public override void Speed()
//     {
//         Console.WriteLine("test");
//     }
//     public void JetSound()
//     {
//         Console.WriteLine("WUUUUSSSHHHHH!!!!");
//     }
//     public void MachineBrand()
//     {
//         Console.WriteLine("GD-90024-IIXD");
//     }
//     public void PropellerBrand()
//     {
//         Console.WriteLine("Duraking 9001");
//     }
//     public void WheelBrand()
//     {
//         Console.WriteLine("Dunllop 10032");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         GarudaAirPlane garuda = new();
//         garuda.Speed();
//         garuda.JetSound();
//         garuda.MachineBrand();
//         garuda.PropellerBrand();
//         garuda.WheelBrand();
//     }
// }

interface IAirplane
{
    void AirplaneList();
}

abstract class AirplaneMachine //abstract: 1 method with no body and 1 with body. abstract harus di gunakan menggunakan override pada pemanggil method
{
    public abstract void Speed();
    public void ProductionYear()
    {
        Console.WriteLine("2023");
    }
}

class Airplane : AirplaneMachine, IAirplane
{
    string speedGaruda = "400KM / hours";
    string speedBoeing = "1000KM / hours";
    public override void Speed() // contoh override pada pemanggilan Speed pada abstract class
    {
        Console.WriteLine(speedGaruda);
        Console.WriteLine(speedBoeing);
    }

    public void AirplaneList()
    {
        Console.WriteLine("You're a Pilot, what airplaneList you want to ride?");
        Console.WriteLine("----- Airplane List -----");
        Console.WriteLine("Garuda101");
        Console.WriteLine("Boeing1003");
        Console.WriteLine("-------------------------");
        Console.WriteLine("Exit");
    }
}

class Program
{
    static void Main()
    {
        Airplane airplane = new();

        Console.WriteLine("Please Input your role: ");
        string userRole = Console.ReadLine();
        if (userRole == "Pilot")
        {
            while (true)
            {
                airplane.AirplaneList(); //method dari IAirplane
                string airplaneList = Console.ReadLine();

                if (airplaneList == "Garuda101")
                {
                    Console.WriteLine("Okay you can go to Hangar 1");
                    break;
                }
                if (airplaneList == "Boeing1003")
                {
                    Console.WriteLine("Okay you can go to Hangar 2-B");
                    break;
                }
                if (airplaneList == "Exit")
                {
                    Console.WriteLine("Okay See You Again!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please input the right option!");
                }
            }
        }
        else
        {
            Console.WriteLine("The role is false, exit from the system!");
        }
    }
}