// JSON with manual input
// using System.Text.Json;

// class Human
// {
//   public string Name { get; set; }
//   public int Age { get; set; }
//   public string Address { get; set; }

//   public Human(string name, int age, string address)
//   {
//     Name = name;
//     Age = age;
//     Address = address;
//   }
// }

// class Program
// {
//   static void Main()
//   {
//     Human yusa = new Human("Yusa", 26, "Tulungagung");
//     Human ega = new Human("Ega", 22, "Semarang");
//     Human rizqi = new Human("Rizqi", 24, "Bandung");
//     Human fadl = new Human("Fadl", 24, "Jakarta");
//     Human dewi = new Human("Dewi", 25, "Pati");
//     Human wulan = new Human("Wulan", 29, "Bandung");
//     Human bela = new Human("Bela", 24, "Kediri");
//     Human jun = new Human("Jun", 23, "Balikpapan");

//     List<Human> bootcamp = new List<Human>()
//   {
//     yusa,ega,rizqi,fadl,dewi,wulan,bela,jun
//   };

//     string json = JsonSerializer.Serialize(bootcamp);
//     using (StreamWriter sw = new("file.json"))
//     {
//       sw.WriteLine(json);
//     }
//   }
// }

// JSON with readline
// using System.Text.Json;

// class Human
// {
//   public string Name { get; set; }
//   public int Age { get; set; }
//   public string Address { get; set; }

//   public Human(string name, int age, string address)
//   {
//     Name = name;
//     Age = age;
//     Address = address;
//   }
// }

// class Program
// {
//   static void Main()
//   {
//     Console.WriteLine("name: ");
//     string name = Console.ReadLine();

//     Console.WriteLine("age: ");
//     int age = Convert.ToInt32(Console.ReadLine());

//     Console.WriteLine("address: ");
//     string address = Console.ReadLine();

//     Human people = new Human(name, age, address);


//     List<Human> bootcamp = new List<Human>() { people };

//     string json = JsonSerializer.Serialize(bootcamp);
//     using (StreamWriter sw = new("file.json"))
//     {
//       sw.WriteLine(json);
//     }
//   }
// }

// JSON with Deserialize
using System.Text.Json;

class Human
{
  public string Name { get; set; }
  public int Age { get; set; }
  public string Address { get; set; }

  public Human(string name, int age, string address)
  {
    Name = name;
    Age = age;
    Address = address;
  }
}

class Program
{
  static void Main()
  {
    string result;
    using (StreamReader sr = new StreamReader("file.json"))
    {
      result = sr.ReadToEnd();
    }

    List<Human> bootcamp = JsonSerializer.Deserialize<List<Human>>(result);
    foreach (var human in bootcamp)
    {
      Console.WriteLine($"Name: {human.Name}");
      Console.WriteLine($"Age: {human.Age}");
    }
  }
}