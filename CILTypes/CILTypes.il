.assembly extern System.Runtime
{
    .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
    .ver 6:0:0:0
}
.assembly extern System.Runtime.Extensions
{
    .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
    .ver 6:0:0:0
}
.assembly extern mscorlib
{
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
    .ver 6:0:0:0
}

.assembly CILTypes
{
    .ver 1:0:0:0
}
.module CILTypes.dll

.namespace MyNamespace
{
    .class public interface IMyInterface {}
    .class public interface IMyOtherIface
        implements MyNamespace.IMyInterface {}

    .class public MyBaseClass
    {
        .field private string stringField = "Hello"
        .field private int32 intField = int32(42)

        .method public hidebysig specialname rtspecialname
          instance void .ctor(string s, int32 i) cil managed
        {
            // stringField = s
            // intField = i
            ret
        }

        .method public hidebysig specialname
          instance string get_TheString() cil managed
        {

        }
        .method public hidebysig specialname
          instance void set_TheString(string 'value') cil managed
        {
            ret
        }
        .property instance string TheString()
        {
            .get instance string MyNamespace.MyBaseClass::get_TheString()
            .set instance void MyNamespace.MyBaseClass::set_TheString(string)
        }

        .method public static void MyMethod(int32 inputInt,
            int32 &refInt,
            class [System.Runtime.Extensions]System.Collections.ArrayList ar,
            [out] int32 &outputInt) cil managed
        {
            ret
        }

        .method public hidebysig static void MyLocalVariables() cil managed
        {
            .maxstack 8
            .locals init (string myString, int32 myInt, object myObj)
            ldstr "CIL code is fun!"
            stloc.0
            ldc.i4.s 33
            stloc.1

            newobj instance void [mscorlib]System.Object::.ctor()
            stloc.2
            ret
        }

        .method public hidebysig static int32 Add(int32 a, int32 b)
        {
            .maxstack 2
            ldarg.0
            ldarg.1
            add
        }

    }
    .class public MyDerivedClass
        extends MyNamespace.MyBaseClass
        implements MyNamespace.IMyInterface
    {

    }

    .class public sealed MyStruct1
        extends [System.Runtime]System.ValueType {}
    .class public sealed value MyStruct2 {} //  short-form struct declaration

    .class public sealed MyEnum1
        extends [System.Runtime]System.Enum
        {
            .field public static literal valuetype
             MyNamespace.MyEnum1 A = int32(0)
            .field public static literal valuetype
             MyNamespace.MyEnum1 B = int32(1)
            .field public static literal valuetype
             MyNamespace.MyEnum1 C = int32(2)
        }
    .class public sealed enum MyEnum2 {}
}