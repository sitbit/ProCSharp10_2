// See https://aka.ms/new-console-template for more information
using System.Reflection;

Console.WriteLine("***** External Assembly Viewer *****\n");

string asmName;
Assembly asm;

Console.Write("Enter an assembly to examine: ");
string dir = Environment.CurrentDirectory;
asmName = Console.ReadLine();
//if (!File.Exists(asmName))
//{
//    Console.WriteLine($"{asmName} does not exist!");
//    return;
//}

try
{
    asm = Assembly.LoadFrom(asmName);
    DisplayTypesInAssembly(asm);
}
catch (Exception ex)
{
    Console.WriteLine("Can't load assembly:\n");
    Console.WriteLine($"{ex}\n");
}

Console.WriteLine("Press <Enter> to continue...");
Console.ReadLine();

static void DisplayTypesInAssembly(Assembly asm)
{
    AssemblyName name = asm.GetName();
    Console.WriteLine($"-> Types in {name}");
    Type[] types = asm.GetTypes();
    foreach (Type type in types)
    {
        Console.WriteLine($" - Type: {type}");
    }
    Console.WriteLine();
}