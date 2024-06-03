using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
  static void Main()
  {
    var task = new Task<Dictionary<int, Person>>(ReturnDict);
    task.Start();
    foreach (var data in task.Result)
    {
      Console.WriteLine($"ID: {data.Key}, Name: {data.Value.Name}, Address: {data.Value.Address}, Telephone: {data.Value.Telephone}");
    }
  }

  static Dictionary<int, Person> ReturnDict()
  {
    Dictionary<int, Person> dict = new();
    dict.Add(1, new Person { Name = "Yuza", Address = "123 Main St", Telephone = "123-456-7890" });
    dict.Add(2, new Person { Name = "Yuza", Address = "123 Main St", Telephone = "123-456-7890" });
    dict.Add(3, new Person { Name = "Yuza", Address = "123 Main St", Telephone = "123-456-7890" });
    return dict;
  }
}

class Person
{
  public required string Name { get; set; }
  public required string Address { get; set; }
  public required string Telephone { get; set; }
}
