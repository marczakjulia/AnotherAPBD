namespace AnotherAPBD;

/// <summary>
/// Class extending the IPowerNotify interface, that is just responsible for informing the user of the low battery level
/// </summary>
public class ConsoleNotifier : IPowerNotify
{
    public void Notify(int batteryLevel)
    {
        Console.WriteLine($"Battery level is low. Current level is: {batteryLevel}%");
    }
}
