namespace BackgroundThreads;

public class Printer
{
    public void PrintNumbers()
    {
        Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing PrintNumbers()");
        Console.WriteLine("Your numbers:");
        for (int i = 0; i < 10; ++i)
        {
            Console.Write($"{i}, ");
            Thread.Sleep(2000);
        }
        Console.WriteLine();
    }
}
