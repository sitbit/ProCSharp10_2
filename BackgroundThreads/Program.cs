// See https://aka.ms/new-console-template for more information
using BackgroundThreads;

Console.WriteLine("***** Background Threads *****");

Printer p = new();
Thread bgThread = new(new ThreadStart(p.PrintNumbers));
bgThread.IsBackground = true;
bgThread.Start();

Console.ReadLine();