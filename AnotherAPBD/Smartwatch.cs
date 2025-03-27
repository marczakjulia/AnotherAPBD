namespace AnotherAPBD;

/// <summary>
/// Smartwatch class, yet not the logic of battery is in a seperate class, same with id validation
/// </summary>
 public class Smartwatch : Device
 {
     public static IIdValidator IdValidator { get; set; } = new SmartWatchIdValidator();
    public Battery Battery { get; private set; }
    public Smartwatch(string id, string name, bool isEnabled, int batteryLevel) : base(id, name, isEnabled)
    {
        IdValidator.ValidateOrThrow(id);
        Battery = new Battery(batteryLevel, new ConsoleNotifier());
    }

    public override void TurnOn()
    {
        if (!Battery.HasSufficientPower(11))
        {
            throw new EmptyBatteryException();
        }
        base.TurnOn();
        Battery.UseUpBattery(10);
    }
    public override string ToString()
    {
        string enabledStatus = IsEnabled ? "enabled" : "disabled";
        return $"Smartwatch {Name} ({Id}) is {enabledStatus} and has {Battery.Level}% battery";
    }
    public override string ToSavingString()
    {
        return $"{Id},{Name},{IsEnabled},{Battery.Level}%";
    }
}
    
