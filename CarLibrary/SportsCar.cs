namespace CarLibrary;

public class SportsCar : Car
{
    public SportsCar() { }
    public SportsCar(string name, int currSpeed, int maxSpeed) : base(name, currSpeed, maxSpeed) { }

    public override void TurboBoost()
    {
        Console.WriteLine("Ramming speed! Faster is better...");
    }
}
