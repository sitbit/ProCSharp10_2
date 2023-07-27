namespace ThreadPoolApp;

public class Printer
{
    private readonly object threadLock = new();
    public void PrintNumbers()
    {
        lock (threadLock)
        {
            Console.WriteLine($"-> {Environment.CurrentManagedThreadId} is executing PrintNumbers()");
            Console.WriteLine("Your numbers:");
            for (int i = 0; i < 10; ++i)
            {
                Random r = new();
                Thread.Sleep(100 * r.Next(5));
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }
    }
}
