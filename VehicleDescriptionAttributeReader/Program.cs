// See https://aka.ms/new-console-template for more information
using AttributedCarLibrary;

Console.WriteLine("***** Vehicle Description Attribute Reader App *****\n");

ReflectOnAttributesUsingEarlyBinding();

Console.ReadLine();

static void ReflectOnAttributesUsingEarlyBinding()
{
    Type t = typeof(Winnebago);

    object[] customAtts = t.GetCustomAttributes(false);

    foreach (VehicleDescriptionAttribute attr in customAtts)
    {
        Console.WriteLine(attr.Description);
    }
}