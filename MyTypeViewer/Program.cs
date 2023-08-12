// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Text;

Console.WriteLine("***** Type Viewer *****\n");

string typeName = "System.Math";
Console.WriteLine($"Examining {typeName}\n");

try
{
    Type type = Type.GetType(typeName);
    ListTypeStats(type);
    ListFields(type);
    ListProperties(type);
    ListMethods(type);
    ListInterfaces(type);
}
catch
{
    Console.WriteLine($"Sorry, can't find type: {typeName}");
}

Console.ReadLine();

#pragma warning disable CS8321 // Local function is declared but never used

static string GetMethodPrototypeAsString(MethodInfo method)
{
    StringBuilder sb = new();

    _ = sb.Append($"{method.ReturnType.Name,-15} {method.Name,-15} (");
    ParameterInfo[] parms = method.GetParameters();
    List<string> paramString = new();
    foreach (ParameterInfo pi in parms)
    {
        paramString.Add($"{pi.ParameterType.Name} {pi.Name}");
    }
    _ = sb.Append(string.Join(", ", paramString));
    _ = sb.Append(")");

    return sb.ToString();
}
static void ListFields(Type type)
{
    var fields = from f in type.GetFields() orderby f.Name select f.Name;
    if (!fields.Any())
    {
        return;
    }
    Console.WriteLine($"-> Fields\n");
    foreach (string field in fields)
    {
        Console.WriteLine(field);
    }
    Console.WriteLine();
}
static void ListInterfaces(Type type)
{
    var ifaces = from i in type.GetInterfaces() orderby i.Name select i.Name;
    if (!ifaces.Any())
    {
        return;
    }
    Console.WriteLine($"-> Interfaces\n");
    foreach (string name in ifaces)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine();
}
static void ListMethods(Type type)
{
    var miNames = from mi in type.GetMethods() orderby mi.Name select mi;
    if (!miNames.Any())
    {
        return;
    }
    Console.WriteLine($"-> Methods\n");
    foreach (MethodInfo m in miNames)
    {
        //Console.WriteLine($"{m}");
        Console.WriteLine(GetMethodPrototypeAsString(m));
    }
    Console.WriteLine();
}
static void ListProperties(Type type)
{
    var properties = from p in type.GetProperties() orderby p.Name select p.Name;
    if (!properties.Any())
    {
        return;
    }
    Console.WriteLine($"-> Properties\n");
    foreach (string name in properties)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine();
}
static void ListTypeStats(Type type)
{
    Console.WriteLine($"-> Stats\n");
    Console.WriteLine($"Base class: {type.BaseType.Name}");
    Console.WriteLine($"Is abstract? {type.IsAbstract}");
    Console.WriteLine($"Is sealed? {type.IsSealed}");
    Console.WriteLine($"Is generic? {type.IsGenericTypeDefinition}");
    Console.WriteLine($"Is class? {type.IsClass}");
    Console.WriteLine();
}