namespace CarLibrary;

public class MiniVan : Car
{
    public MiniVan() { }
    public MiniVan(string name, int currSpeed, int maxSpeed) : base(name, currSpeed, maxSpeed) { }

    public override void TurboBoost()
    {
        EngineState = EngineStateEnum.EngineDead;
        Console.WriteLine("Eek!  Your engine block exploded!");
    }
}
