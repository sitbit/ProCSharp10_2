// See https://aka.ms/new-console-template for more information
using System.Reflection;

Console.WriteLine("***** Framework Assembly Viewer *****\n");

string displayName = "Microsoft.EntityFrameworkCore, Version=7.0.10.0, Culture=neutral, PublicKeyToken=adb9793829ddae60";
Assembly asm = Assembly.Load(displayName);
DisplayInfo(asm);

Console.ReadLine();

static void DisplayInfo(Assembly asm)
{
    AssemblyName asmName = asm.GetName();
    Console.WriteLine($"Assembly name: {asmName.Name}");
    Console.WriteLine($"Assembly version: {asmName.Version}");
    Console.WriteLine($"Assembly culture: {asmName.CultureInfo.DisplayName}");

    Console.WriteLine("Public enums:");
    var enums = asm.GetTypes().Where(e => e.IsEnum && e.IsPublic);
    foreach (var e in enums)
    {
        Console.WriteLine(e);
    }
}