// See https://aka.ms/new-console-template for more information
Console.WriteLine("***** Thread Stats *****\n");

Thread primaryThread = Thread.CurrentThread;
primaryThread.Name = "ThePrimaryThread";

string info = $"{primaryThread.Name}: {primaryThread.ManagedThreadId}, IsAlive? {primaryThread.IsAlive}, " +
    $"Priority {primaryThread.Priority}, thread state {primaryThread.ThreadState}";
Console.WriteLine(info);

Console.ReadLine();