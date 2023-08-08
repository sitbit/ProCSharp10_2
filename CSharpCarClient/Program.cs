// See https://aka.ms/new-console-template for more information
using CarLibrary;

Console.WriteLine("***** C# CarLibrary Client App *****\n");

#pragma warning disable IDE0059 // Unnecessary assignment of a value
var internalClassInstance = new MyInternalClass();
#pragma warning restore IDE0059 // Unnecessary assignment of a value

SportsCar viper = new("Viper", 40, 240);
viper.TurboBoost();

MiniVan mv = new();
mv.TurboBoost();

Console.WriteLine("Press <Enter> to continue...");
Console.ReadLine();