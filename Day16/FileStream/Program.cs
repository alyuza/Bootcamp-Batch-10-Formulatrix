// using System.Text;

// class Program
// {
//   static void Main()
//   {
//     using (FileStream fs = new FileStream("test1.txt", FileMode.Create, FileAccess.Write, FileShare.None))
//     {
//       string text = "Selamat pagi";
//       byte[] myBytes = new byte[text.Length];
//       myBytes = Encoding.UTF8.GetBytes(text);
//       fs.Write(myBytes, 0, myBytes.Length);
//     }

//     using (FileStream fs1 = File.OpenRead("test1.txt"))
//     {
//       byte[] b = new byte[1024];
//       UTF8Encoding tmp = new UTF8Encoding(true);
//       int readLen;
//       while ((readLen = fs1.Read(b, 0, b.Length)) > 0)
//       {
//         Console.WriteLine(tmp.GetString(b, 0, readLen));
//       }
//     }
//     Console.ReadLine();
//   }
// }

using System;

class Program
{
  static void Main()
  {
    string filePath = "text2.txt";

    using (StreamWriter writer = new(filePath))
    {
      writer.WriteLine("test");

      
    }
  }
}