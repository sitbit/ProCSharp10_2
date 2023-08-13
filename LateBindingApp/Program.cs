// See https://aka.ms/new-console-template for more information
using System.Reflection;

Console.WriteLine("***** Demo Late Binding *****\n");

Assembly a = null;
try
{
    a = Assembly.LoadFrom("CarLibrary");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

if (a != null)
{
    CreateUsingLateBinding(a);
}

Console.ReadLine();

static void CreateUsingLateBinding(Assembly asm)
{
    try
    {
        Type MiniVan = asm.GetType("CarLibrary.MiniVan");

        object obj = Activator.CreateInstance(MiniVan);
        Console.WriteLine($"Created a {obj} using late binding!");

        MethodInfo mi = MiniVan.GetMethod("TurboBoost");
        _ = mi.Invoke(obj, null);

        PropertyInfo pi = MiniVan.GetProperty("EngineState");
        Console.WriteLine($"{pi.GetValue(obj)}");

        Type SportsCar = asm.GetType("CarLibrary.SportsCar");
        obj = Activator.CreateInstance(SportsCar);

        mi = SportsCar.GetMethod("TurnOnRadio");
        _ = mi.Invoke(obj, new object[] { true, 2 });
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}