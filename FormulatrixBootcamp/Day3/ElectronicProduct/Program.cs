using Computer;
class Program
{
    static void Main()
    {
        Product.Monitor monitor = new Product.Monitor("Dell", 1920, 1080, "4K");
        monitor.DisplayMonitor();

        Computer.Processor processor = new("Intel ", "Core I9", 4.4f);
        Computer.PC pc = new Computer.PC("Asus", 2023, processor);
        pc.DisplayPC();
    }
}