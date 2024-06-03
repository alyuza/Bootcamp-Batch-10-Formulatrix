using System;
using System.Diagnostics;
using System.Xml.Serialization;

class Program
{
  static void Main()
  {
    Human yusa = new Human("Yusa", 26, "Tulungagung");
    Human ega = new Human("Ega", 22, "Semarang");
    Human rizqi = new Human("Rizqi", 24, "Bandung");
    Human fadl = new Human("Fadl", 24, "Jakarta");
    Human dewi = new Human("Dewi", 25, "Pati");
    Human wulan = new Human("Wulan", 29, "Bandung");
    Human bela = new Human("Bela", 24, "Kediri");
    Human jun = new Human("Jun", 23, "Balikpapan");

    List<Human> bootcamp = new List<Human>()
      {
        yusa,ega,rizqi,fadl,dewi,wulan,bela,jun
      };

    XmlSerializer xmlSerialization = new(typeof(List<Human>));
    using (StreamWriter sw = new("file.xml"))
    {
      xmlSerialization.Serialize(sw, bootcamp);
    }
  }
}

public class Human
{
  public string Name { get; set; }
  public int Age { get; set; }
  public string Address { get; set; }

  public Human() { }
  public Human(string name, int age, string address)
  {
    Name = name;
    Age = age;
    Address = address;
  }
}