// See https://aka.ms/new-console-template for more information
Console.WriteLine("***** Timer App *****");

TimerCallback timerCallback = new(PrintTime);

_ = new Timer(
    timerCallback,
    "Hello, world!",
    0,
    1000
    );

Console.WriteLine("Press <Enter> to stop...");
Console.ReadLine();

static void PrintTime(object state)
{
    Console.WriteLine($"{state}, the time is: {TimeOnly.FromDateTime(DateTime.Now).ToLongTimeString()}");
}