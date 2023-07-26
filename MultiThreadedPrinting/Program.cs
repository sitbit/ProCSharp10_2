// See https://aka.ms/new-console-template for more information
using MultiThreadedPrinting;

Console.WriteLine("***** Multi-Threaded Printing *****");

Printer p = new();
Thread[] threads =  new Thread[10];
for (int i = 0; i < threads.Length; ++i)
{
    threads[i] = new(new ThreadStart(p.PrintNumbers))
    {
        Name = $"Worker thread #{i}"
    };
}
foreach (Thread t in threads)
{
    t.Start();
}

Console.WriteLine("Press <Enter> to continue...");
Console.ReadLine();