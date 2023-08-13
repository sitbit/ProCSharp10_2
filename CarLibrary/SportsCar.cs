namespace CarLibrary;

public class SportsCar : Car
{
    MusicMediaEnum music = MusicMediaEnum.MusicCD;
    bool listeningToMusic = false;
    public SportsCar() { }
    public SportsCar(string name, int currSpeed, int maxSpeed) : base(name, currSpeed, maxSpeed) { }

    public override void TurboBoost()
    {
        Console.WriteLine("Ramming speed! Faster is better...");
    }
    public void TurnOnRadio(bool? musicOn, MusicMediaEnum media)
    {
        if (musicOn != null)
        {
            music = media;
            listeningToMusic = musicOn == true;
        }
        Console.WriteLine(listeningToMusic ? $"Jamming {music}" : "Quiet time...");
    }
}
