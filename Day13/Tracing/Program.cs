using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine("Program dimulai.");

        int a = 5;
        int b = 3;
        int result = Add(a, b);
        Trace.WriteLine($"Hasil penjumlahan {a} + {b} adalah {result}.");

        Trace.WriteLine("Program selesai.");
        Trace.Flush();
    }

    static int Add(int a, int b)
    {
        Trace.WriteLine($"Masuk ke metode Add dengan a={a}, b={b}");
        int result = a + b;
        Trace.WriteLine($"Keluar dari metode Add dengan hasil {result}");
        return result;
    }
}
