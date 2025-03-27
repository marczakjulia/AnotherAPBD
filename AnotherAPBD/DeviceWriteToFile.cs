namespace AnotherAPBD
{
    public static class DeviceWriteToFile
    {
        /// <summary>
        /// Saves the provided list of devices to the specified file.
        /// </summary>
        public static void SaveDevices(string outputPath, IEnumerable<Device> devices)
        {
            var linesList = new List<string>();
            foreach (Device device in devices)
            {
                linesList.Add(device.ToSavingString());
            }
            File.WriteAllLines(outputPath, linesList.ToArray());
        }
    }
}