// See https://aka.ms/new-console-template for more information
using CarLibrary;

Console.WriteLine("***** C# CarLibrary Client App *****\n");

SportsCar viper = new("Viper", 40, 240);
viper.TurboBoost();

MiniVan mv = new();
mv.TurboBoost();

Console.WriteLine("Press <Enter> to continue...");
Console.ReadLine();