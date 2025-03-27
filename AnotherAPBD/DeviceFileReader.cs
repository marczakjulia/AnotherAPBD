namespace AnotherAPBD;


/// <summary>
/// A class that is responsible for reading the input file with the initial devices
/// </summary>
public static class DeviceFileReader
{
    public static string[] ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The input device file could not be found.");
        }
        return File.ReadAllLines(filePath);
    }
}
