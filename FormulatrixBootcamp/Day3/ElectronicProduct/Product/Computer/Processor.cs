using System;

namespace Computer
{
    class Processor
    {
        private string brand;
        private string cpu;
        private float clockSpeed;

        public Processor(string brand, string cpu, float clockSpeed)
        {
            this.brand = brand;
            this.cpu = cpu;
            this.clockSpeed = clockSpeed;
        }

        public void DisplayProcessor()
        {
            Console.WriteLine($"Processor: {brand}{cpu}\nClock Speed: {clockSpeed}");
            Console.WriteLine("==============================");
        }
    }
}
