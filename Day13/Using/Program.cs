// class Program
// {
//   static void Main()
//   {
//     string filePath = "../file.txt";
//     string fileMessage = "Hello world 2";

//     FileManager fm = new();
//     fm.Write(filePath, fileMessage); // parameters (path, message)
//   }
// }

// class FileManager
// {
//   public void Write(string path, string message)
//   {
//     using (StreamWriter stream = new(path, false))
//     {
//       stream.WriteLine(message);
//     }
//   }
//   public string ReadLine(string path)
//   {
//     string result;
//     using (StreamReader stream = new StreamReader(path))
//     {
//       result = stream.ReadLine();
//     }
//     return result;
//   }
// }

// Collection
// using System.Collections.Generic;

// List<string> playersName = new()
// {
//   "alyuza","yuza"
// };

// Dictionary 

// playersName.Add("yuza");
// playersName.Add("yuza");
// playersName.Add("yuza");

// string[] playersName = new();