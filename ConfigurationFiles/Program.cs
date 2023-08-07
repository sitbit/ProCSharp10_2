// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

Console.WriteLine("***** Configuration Files *****\n");

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile("appsettings.development.json", true, true)
    .Build();

Console.WriteLine($"My first car's name is: '{config["CarName"]}'");
Console.WriteLine();
Console.WriteLine($"My second car's name is: '{config["CarName2"]}'");
Console.WriteLine($"'CarName2 is null? {config["CarName2"] == null}'");
Console.WriteLine();
Console.WriteLine($"My second car's name is: '{config.GetValue<int>("CarName2")}'");
Console.WriteLine();
try
{
    Console.WriteLine("Convert 'CarName' to int:");
    Console.WriteLine($"My second car's name is: '{config.GetValue<int>("CarName")}'");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"An exception occurred: {ex.Message}");
}
Console.WriteLine();

Console.WriteLine($"My third car is a {config["Car:Color"]} {config["Car:Make"]}" +
    $" named '{config["Car:PetName"]}'");
Console.WriteLine();
Console.WriteLine("Using a section...");
IConfigurationSection section = config.GetSection("Car");
Console.WriteLine($"My third car is a {section["Color"]} {section["Make"]}" +
    $" named '{section["PetName"]}'");
Console.WriteLine();
Console.WriteLine("Using a class...");
Car car = new();
section.Bind(car);
Console.WriteLine($"My third car is a {car.Color} {car.Make}" +
    $" named '{car.PetName}'");
Console.WriteLine();
Console.WriteLine("Using a class when config doesn't exist...");
Car notFound = new()
{
    Color = "Red",
    Make = "BMW",
    PetName = "Mid-Life Crisis"
};
Console.WriteLine("Before:");
Console.WriteLine($"My third car is a {notFound.Color} {notFound.Make}" +
    $" named '{notFound.PetName}'");
config.GetSection("Car2").Bind(notFound);
Console.WriteLine("After:");
Console.WriteLine($"My third car is a {notFound.Color} {notFound.Make}" +
    $" named '{notFound.PetName}'");
Console.WriteLine();
Console.WriteLine("Using the 'Get' method...");
Car fromGet = config.GetSection("Car").Get(typeof(Car)) as Car;
Console.WriteLine($"My third car is a {fromGet.Color} {fromGet.Make}" +
    $" named '{fromGet.PetName}'");
Console.WriteLine();
Console.WriteLine("If 'Get' can't find the section...");
notFound = config.GetSection("Car2").Get(typeof(Car)) as Car;
Console.WriteLine($"Not-found car is null? {notFound == null}");
Console.WriteLine();
Console.WriteLine("Using the generic 'Get' method...");
fromGet = config.GetSection("Car").Get<Car>();
Console.WriteLine($"My third car is a {fromGet.Color} {fromGet.Make}" +
    $" named '{fromGet.PetName}'");
Console.WriteLine();
Console.WriteLine("If generic 'Get' can't find the section...");
notFound = config.GetSection("Car2").Get<Car>();
Console.WriteLine($"Not-found car is null? {notFound == null}");

internal class Car
{
    public string Color { get; set; }
    public string Make { get; set; }
    public string PetName { get; set; }
}