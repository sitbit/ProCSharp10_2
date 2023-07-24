// See https://aka.ms/new-console-template for more information
using AddWithThreads;

AutoResetEvent _waitHandle = new(false);

Console.WriteLine("***** Add With Threads *****\n");

Console.WriteLine($"ID of thread in Main: {Environment.CurrentManagedThreadId}");
AddParams addParams = new(20, 10);
Thread t = new(new ParameterizedThreadStart(Add));
t.Start(addParams);

//Thread.Sleep(1000);
_ = _waitHandle.WaitOne();
Console.WriteLine("Press <Enter> to continue...");
Console.ReadLine();

void Add(object data)
{
    if (data is AddParams ad)
    {
        Console.WriteLine($"-> on thread (ID): {Environment.CurrentManagedThreadId}");
        Console.WriteLine($"{ad.a} + {ad.b} = {ad.a + ad.b}");
        _ = _waitHandle.Set();
    }
}