using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

[DataContract]
class Player
{
  [DataMember]
  private string _name;
  [DataMember]
  private int _money;
  [DataMember]
  public int Gold { get; set; }
  [DataMember]
  public int Exp { get; set; }
  public Player(string name, int money, int gold, int exp)
  {
    _name = name;
    _money = money;
    Gold = gold;
    Exp = exp;
  }

  public string GetName()
  {
    return _name;
  }

  public int GetMoney()
  {
    return _money;
  }
}

class Program
{
  static void Main()
  {
    Player juan = new Player("Juan", 2000, 300, 1500);
    Player reno = new Player("Reno", 4000, 500, 3500);
    Player didi = new Player("Didi", 6000, 700, 4500);

    List<Player> players = new List<Player>()
    {
        juan,reno,didi
    };

    DataContractJsonSerializer serializer = new(typeof(List<Player>));
    using (FileStream fs = new("players.json", FileMode.Create))
    {
      serializer.WriteObject(fs, players);
    }
  }
}