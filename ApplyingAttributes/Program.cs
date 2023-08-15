// See https://aka.ms/new-console-template for more information
global using System.Text.Json.Serialization;
global using System.Xml.Serialization;
using ApplyingAttributes;

Console.WriteLine("***** Applying Attributes *****\n");

#pragma warning disable IDE0059 // Unnecessary assignment of a value
HorseAndBuggy horseAndBuggy = new();
#pragma warning restore IDE0059 // Unnecessary assignment of a value

Console.ReadLine();