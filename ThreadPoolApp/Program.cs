// See https://aka.ms/new-console-template for more information
using ThreadPoolApp;

Console.WriteLine("***** Thread Pool App *****\n");

Console.WriteLine($"Main thread started; ID: {Environment.CurrentManagedThreadId}");
Printer p = new();

WaitCallback workItem = new(PrintTheNumbers);

for (int i = 0; i < 10; ++i)
{
    _ = ThreadPool.QueueUserWorkItem(workItem, p);
}

Console.WriteLine("Press <Enter> to continue...");
Console.ReadLine();

static void PrintTheNumbers(object state)
{
    Printer task = (Printer)state;
    task.PrintNumbers();
}