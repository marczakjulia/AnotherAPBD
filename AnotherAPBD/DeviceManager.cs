using System.Text;

namespace AnotherAPBD
{
    /// <summary>
    /// Class, that extents the IDeviceRepo that is responsible for all operations on devices, meaning the adding or deleting 
    /// </summary>
    public class DeviceManager : IDeviceRepository
    {
        private readonly IDeviceParser _deviceParser;
        private const int MaxCapacity = 15;
        private readonly List<Device> _devices = new(MaxCapacity);

        public DeviceManager(string[] lines, IDeviceParser deviceParser)
        {
            _deviceParser = deviceParser;
            ParseDevices(lines);
        }
        /// <summary>
        ///Function for adding new devices </summary>
        ///<param name="newDevice">instance of device </param>
        public void AddDevice(Device newDevice)
        {
            foreach (var storedDevice in _devices)
            {
                if (storedDevice.Id.Equals(newDevice.Id))
                {
                    throw new ArgumentException($"Device with ID {storedDevice.Id} is already stored.", nameof(newDevice));
                }
            }
            if (_devices.Count >= MaxCapacity)
            {
                throw new Exception("Device storage is full.");
            }
            _devices.Add(newDevice);
        }
        /// <summary>
        ///Function for adding editing devices </summary>
        ///<param name="editDevice">instance of device </param>
        public void EditDevice(Device editDevice)
        {
            int targetDeviceIndex = -1;
            for (int index = 0; index < _devices.Count; index++)
            {
                if (_devices[index].Id.Equals(editDevice.Id))
                {
                    targetDeviceIndex = index;
                    break;
                }
            }
            if (targetDeviceIndex == -1)
            {
                throw new ArgumentException($"Device with ID {editDevice.Id} is not stored.", nameof(editDevice));
            }
            if (_devices[targetDeviceIndex].GetType() != editDevice.GetType())
            {
                throw new ArgumentException($"Type mismatch between devices. Target device has type {_devices[targetDeviceIndex].GetType().Name}");
            }
            _devices[targetDeviceIndex] = editDevice;
        }
        /// <summary>
        ///Function for adding removing devices </summary>
        ///<param name="deviceId">id of function </param>
        public void RemoveDeviceById(string deviceId)
        {
            Device targetDevice = null;
            foreach (var storedDevice in _devices)
            {
                if (storedDevice.Id.Equals(deviceId))
                {
                    targetDevice = storedDevice;
                    break;
                }
            }
            if (targetDevice == null)
            {
                throw new ArgumentException($"Device with ID {deviceId} is not stored.", nameof(deviceId));
            }
            _devices.Remove(targetDevice);
        }
        
        /// <summary>
        ///Function for fetching device s </summary>
        ///<param name="id">id of device </param>
        public Device GetDeviceById(string id)
        {
            foreach (var storedDevice in _devices)
            {
                if (storedDevice.Id.Equals(id))
                {
                    return storedDevice;
                }
            }
            return null;
        }
        
        public void ShowAllDevices()
        {
            foreach (var device in _devices)
            {
                Console.WriteLine(device.ToString());
            }
        }
        /// <summary>
        ///Function for saving devices</summary>
        ///<param name="outputPath">path to txt file</param>
        public void SaveDevices(string outputPath)
        {
            var lines = _devices.Select(d => d.ToSavingString()).ToArray();
            File.WriteAllLines(outputPath, lines);
        }

        private void ParseDevices(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    Device parsedDevice = _deviceParser.ParseDevice(lines[i], i);
                    AddDevice(parsedDevice);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong during parsing line: {lines[i]}. Exception: {ex.Message}");
                }
            }
        }
    }
}
