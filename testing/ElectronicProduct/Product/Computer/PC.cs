using System;

namespace Computer
{
    class PC
    {
        private string brand;
        private int yearProduction;
        private Processor processor;

        public PC(string brand, int yearProduction, Processor processor)
        {
            this.brand = brand;
            this.yearProduction = yearProduction;
            this.processor = processor;
        }

        public void DisplayPC()
        {
            Console.WriteLine($"Brand PC: {brand}\nYear Production: {yearProduction}");
            processor.DisplayProcessor();
        }
    }
}
