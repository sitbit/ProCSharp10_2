// See https://aka.ms/new-console-template for more information
Console.WriteLine("***** Probing Paths *****\n");

Console.WriteLine("TRUSTED_PLATFORM_ASSEMBLIES");
List<string> list = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES").ToString().Split(';').ToList();
foreach (string dir in list)
{
    Console.WriteLine(dir);
}
Console.WriteLine($"PLATFORM_RESOURCE_ROOTS: {AppContext.GetData("PLATFORM_RESOURCE_ROOTS")}");
Console.WriteLine();
Console.WriteLine($"NATIVE_DLL_SEARCH_DIRECTORIES: {AppContext.GetData("NATIVE_DLL_SEARCH_DIRECTORIES")}");
Console.WriteLine();
Console.WriteLine($"APP_PATHS: {AppContext.GetData("APP_PATHS")}");
Console.WriteLine();
Console.WriteLine($"APP_NI_PATHS: {AppContext.GetData("APP_NI_PATHS")}");

Console.ReadLine();