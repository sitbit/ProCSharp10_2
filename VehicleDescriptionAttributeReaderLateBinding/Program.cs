// See https://aka.ms/new-console-template for more information
using System.Reflection;

Console.WriteLine("***** Vehicle Description Attribute Reader App - Late Binding *****\n");

ReflectAttribsUsingLateBinding();

Console.ReadLine();

static void ReflectAttribsUsingLateBinding()
{
    try
    {
        Assembly asm = Assembly.LoadFrom("AttributedCarLibrary");

        Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");

        PropertyInfo propDesc = vehicleDesc.GetProperty("Description");

        Type[] types = asm.GetTypes();

        foreach (Type t in types)
        {
            object[] objs = t.GetCustomAttributes(vehicleDesc, false);
            foreach (object obj in objs)
            {
                Console.WriteLine($"-> {t.Name}: {propDesc.GetValue(obj, null)}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}