// See https://aka.ms/new-console-template for more information
#pragma warning disable IDE0059 // Unnecessary assignment of a value
using Microsoft.CSharp.RuntimeBinder;
using System.Diagnostics;
using System.Reflection;

Console.WriteLine("Hello, World!");

ImplicitlyTypedVariable();
Console.WriteLine();
ChangeDynamicDataType();
Console.WriteLine();
InvokeMembersOnDynamicData();
Console.WriteLine();
InvokeMethodWithDynamicKeyword();

Console.ReadLine();

static void ChangeDynamicDataType()
{
    Console.WriteLine("-> Change Dynamic Data Type");
    dynamic t = "Hello";
    Console.WriteLine($"t is of type {t.GetType()}");

    t = false;
    Console.WriteLine($"t is of type {t.GetType()}");

    t = new List<int>();
    Console.WriteLine($"t is of type {t.GetType()}");
}
static void ImplicitlyTypedVariable()
{
    Console.WriteLine("-> Implicitly Typed Variable");
    //  'a' is of type List<int>
    var a = new List<int> { 90 };
    //  The following causes a compile-time error!
    //a = "Hello!";
}
static void InvokeMembersOnDynamicData()
{
    Console.WriteLine("-> Invoke Members On Dynamic Data");
    dynamic text = "Hello";

    try
    {
        Console.WriteLine(text.ToUpper());
        Console.WriteLine(text.toupper());
        Console.WriteLine(text.Foo(10, "ee", DateTime.Now));
    }
    catch (RuntimeBinderException ex)
    {
        Console.WriteLine($"RuntimeBinderException: {ex.Message}");
    }
}
static void InvokeMethodWithDynamicKeyword()
{
    Console.WriteLine("-> Invoke Method With Dynamic Keyword");
    try
    {
        Assembly asm = Assembly.LoadFrom("CarLibrary");
        Type miniVan = asm.GetType("CarLibrary.MiniVan");
        dynamic mv = Activator.CreateInstance(miniVan);
        mv.TurboBoost();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}