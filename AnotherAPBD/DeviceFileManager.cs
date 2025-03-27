using System;
using System.Collections.Generic;
using System.IO;

// i hope you meant this, that this class now provides both reading from and writing to a file
// this class acts as the connection between the application and the file system, technically having 
//only one main functionality. i hope i understand your comment correctly :)

namespace AnotherAPBD
{
    /// <summary>
    /// responsible for handling file operations 
    /// </summary>
    public class DeviceFileManager
    {
        /// <summary>
        /// reads all lines from the specified file.
        /// </summary>
        /// <param name="filePath">path of the file to read.</param>
        /// <exception cref="FileNotFoundException">thrown if the file does not exist </exception>
        public virtual string[] ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The input device file could not be found.");
            }
            return File.ReadAllLines(filePath);
        }

        /// <summary>
        /// saves the devices to file.
        /// </summary>
        /// <param name="outputPath"> path of the file to write to.</param>
        /// <param name="devices">list of devices to save.</param>
        public virtual void SaveDevices(string outputPath, List<Device> devices)
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
