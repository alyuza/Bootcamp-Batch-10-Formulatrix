using System;

namespace Product
{
    class Monitor
    {
        private string brand;
        private int width;
        private int height;
        private string resolution;

        public Monitor(string brand, int width, int height, string resolution)
        {
            this.brand = brand;
            this.width = width;
            this.height = height;
            this.resolution = resolution;
        }

        public void DisplayMonitor()
        {
            Console.WriteLine("==============================");
            Console.WriteLine($"Brand Monitor: {brand}\nWidth: {width}\nHeight: {height}\nResolution: {resolution}");
            Console.WriteLine("==============================");
        }
    }
}
