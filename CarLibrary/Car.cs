//  Handled in .csproj
//using System.Runtime.CompilerServices;
//[assembly:InternalsVisibleTo("CSharpCarClient")]
namespace CarLibrary;
public abstract class Car
{
    public string PetName { get; set; }
    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; }

    protected EngineStateEnum State = EngineStateEnum.EngineAlive;
    public EngineStateEnum EngineState
    {
        get => State;
        set => State = value;
    }
    public abstract void TurboBoost();

    protected Car() { }
    protected Car(string petName, int currentSpeed, int maxSpeed)
    {
        PetName = petName;
        CurrentSpeed = currentSpeed;
        MaxSpeed = maxSpeed;
    }
}
internal class MyInternalClass { }
