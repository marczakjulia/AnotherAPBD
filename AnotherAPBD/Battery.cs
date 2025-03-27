namespace AnotherAPBD;

/// <summary>
/// Class containing the battery logic, which was earlier in the SW class
/// </summary>
public class Battery
{
    private int _batterylevel;
    private readonly IPowerNotify _notifier;
    public int Level => _batterylevel;
    /// <summary> new instance of battery class . </summary>
    /// <param name="initialLevel">  battery level when creating the device.</param>
    /// <param name="notifier">  interface responsible for the notification  </param>
    /// <exception cref="ArgumentException"> thrown when value of battery is out of range  </exception>

    public Battery(int initialLevel, IPowerNotify notifier)
    {
        if (initialLevel < 0 || initialLevel > 100)
        {
            throw new ArgumentException("Invalid initial battery level. Must be between 0 and 100.", nameof(initialLevel));
        }
        _batterylevel = initialLevel;
        _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        CheckLowBattery();
    }
    private void CheckLowBattery()
    {
        if (_batterylevel < 20)
        {
            _notifier.Notify(_batterylevel);
        }
    }
    public bool HasSufficientPower(int required) => _batterylevel >= required;
    
    public void UseUpBattery(int value)
    {
        _batterylevel -= value;
        if (_batterylevel < 0)
        {
            _batterylevel = 0;
        }
        CheckLowBattery();
    }
}