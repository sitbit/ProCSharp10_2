namespace MultiThreadedPrinting;

public class Printer
{
    public void PrintNumbers()
    {
        Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing PrintNumbers()");
        Console.WriteLine("Your numbers:");
        for (int i = 0; i < 10; ++i)
        {
            Random r = new();
            Thread.Sleep(1000 * r.Next(5));
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
    }
}
