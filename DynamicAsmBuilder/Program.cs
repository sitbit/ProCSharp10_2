// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Reflection.Emit;
using System.Security.AccessControl;

Console.WriteLine("Hello, World!");

var builder = CreateAssembly();

Type hello = builder.GetType("MyAssembly.HelloWorld");

Console.Write("-> Enter message for 'Helloworld': ");
string msg = Console.ReadLine();

object[] ctorArgs = new object[1];
ctorArgs[0] = msg;
object obj = Activator.CreateInstance(hello, ctorArgs);

Console.WriteLine("-> Calling 'SayHello'");
MethodInfo mi1 = hello.GetMethod("SayHello");
mi1.Invoke(obj, null);

MethodInfo mi2 = hello.GetMethod("GetMessage");
Console.WriteLine($"Message: {mi2.Invoke(obj, null)}");

static AssemblyBuilder CreateAssembly()
{
    AssemblyName assemblyName = new()
    {
        Name = "MyAssembly",
        Version = new("1.0.0.0")
    };

    //  Create the dynamic assembly
    var builder = AssemblyBuilder.DefineDynamicAssembly(
        assemblyName,
        AssemblyBuilderAccess.Run);

    //  Define the name of the module
    ModuleBuilder module = builder.DefineDynamicModule("MyAssembly");

    //  Define a public class named 'HelloWorld'
    TypeBuilder helloWorldClass = module.DefineType(
        "MyAssembly.HelloWorld",
        TypeAttributes.Public);

    //  Define the private field, 'theMessage'
    FieldBuilder msgField = helloWorldClass.DefineField(
        "theMessage",
        Type.GetType("System.String"),
        attributes: FieldAttributes.Private);

    //  Define the custom constructor
    Type[] ctorArgs = new Type[1];
    ctorArgs[0] = typeof(string);
    ConstructorBuilder constructor =
        helloWorldClass.DefineConstructor(
            MethodAttributes.Public,
            CallingConventions.Standard,
            ctorArgs);
    ILGenerator constructorIL = constructor.GetILGenerator();
    constructorIL.Emit(OpCodes.Ldarg_0);
    //  Custom ctor calls the super-class (i.e., 'System.Object') constructor
    Type objClass = typeof(object);
    ConstructorInfo superConstructor = objClass.GetConstructor(new Type[0]);
    constructorIL.Emit(OpCodes.Call, superConstructor);

    constructorIL.Emit(OpCodes.Ldarg_0);    //  The 'this' pointer
    constructorIL.Emit(OpCodes.Ldarg_1);    //  The constructor argument
    constructorIL.Emit(OpCodes.Stfld, msgField);    //  store arg1 in 'theMessage' field
    constructorIL.Emit(OpCodes.Ret);

    //  Create the default constructor
    helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);

    //  Create the 'GetMessage' method
    MethodBuilder getMessageMethod = helloWorldClass.DefineMethod(
        "GetMessage",
        MethodAttributes.Public,
        typeof(string),
        null);
    ILGenerator getMessageIL = getMessageMethod.GetILGenerator();
    getMessageIL.Emit(OpCodes.Ldarg_0);
    getMessageIL.Emit(OpCodes.Ldfld, msgField);
    getMessageIL.Emit(OpCodes.Ret);

    //  Create the 'SayHello' method
    MethodBuilder sayHelloMethod = helloWorldClass.DefineMethod(
        "SayHello",
        MethodAttributes.Public,
        null, null);
    ILGenerator sayHelloIL = sayHelloMethod.GetILGenerator();
    sayHelloIL.EmitWriteLine("Hello from the 'HelloWorld' class!");
    sayHelloIL.Emit(OpCodes.Ret);

    //  "Bake" the 'HelloWorld' class
    _ = helloWorldClass.CreateType();

    return builder;
}