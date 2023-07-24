// See https://aka.ms/new-console-template for more information
using SimpleMultiThreadApp;

Console.WriteLine("***** Simple Multi-Threaded App *****\n");

Console.Write("Do you want [1] or [2] threads:");
string threadCount = Console.ReadLine();

Thread primary = Thread.CurrentThread;
primary.Name = "Primary";

Console.WriteLine($"-> {primary.Name} is executing in Main()");

Printer p = new();

switch (threadCount)
{
    case "2":
        Thread background = new(new ThreadStart(p.PrintNumbers));
        background.Name = "Secondary";
        background.Start();
        break;
    case "1":
        p.PrintNumbers();
        break;
    default:
        Console.WriteLine("I don't know what you're asking for... you get 1 thread");
        goto case "1";
}

Console.WriteLine($"Back on the {primary.Name} thread; we're done.");
Console.WriteLine("Press <Enter> to continue.");
Console.ReadLine();