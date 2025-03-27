namespace AnotherAPBD;

/// <summary>
/// Dependency Injection Principle,
/// this function chooses the parser and injects it to DeviceManager class 
/// </summary>
public static class DeviceManagerCreation
{
    public static DeviceManager CreateDeviceManager(string filePath)
    {
        IDeviceParser parser = new DeviceParser();
        string[] lines = DeviceFileReader.ReadFile(filePath);
        return new DeviceManager(lines, parser);
    }
}