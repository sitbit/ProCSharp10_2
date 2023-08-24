// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

Console.WriteLine("***** Late Binding With Dynamic *****\n");

AddWithReflection();
Console.WriteLine();
AddWithDynamic();

Console.ReadLine();

static void AddWithReflection()
{
    Console.WriteLine("-> Add With Reflection\n");
    try
    {
        Assembly asm = Assembly.LoadFrom("MathLibrary");

        Type math = asm.GetType("MathLibrary.SimpleMath");

        object sm = Activator.CreateInstance(math);

        MethodInfo mi = math.GetMethod("Add");

        object[] args = { 10, 70 };
        Console.WriteLine($"SimpleMath.Add(10, 70) = {mi.Invoke(sm, args)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
static void AddWithDynamic()
{
    Console.WriteLine("-> Add With Dynamic()\n");
    try
    {
        Assembly asm = Assembly.LoadFrom("MathLibrary");

        Type math = asm.GetType("MathLibrary.SimpleMath");

        dynamic sm = Activator.CreateInstance(math);

        Console.WriteLine($"SimpleMath.Add(20, 80) = {sm.Add(20, 80)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}