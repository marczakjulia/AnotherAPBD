namespace AnotherAPBD;

/// <summary>
///Interface that notifies about low power
/// </summary>
public interface IPowerNotify
{
    void Notify(int batteryLevel);
}
