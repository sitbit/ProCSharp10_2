Imports System
Imports CarLibrary

Module Program
    Public Sub Main()
        Console.WriteLine("***** VB CarLibrary Client App *****\n")
        Dim myVan = New MiniVan()
        myVan.TurboBoost()

        Dim mySportsCar = New SportsCar()
        mySportsCar.TurboBoost()

        Dim dreamCar As New PerformanceCar With {
            .PetName = "Hank"
        }
        dreamCar.TurboBoost()

        ' This won't compile:
        'Dim internalClassInstance As New MyInternalClass()

        Dim unused = Console.ReadLine()
    End Sub
End Module
