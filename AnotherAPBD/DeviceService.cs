namespace AnotherAPBD
{
    /// <summary>
    ///Class that is responbile for the turning logic of device manager 
    /// </summary>
    public class DeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        /// <summary>
        ///Turns on device if it exists by ID</summary>
        /// <param name="deviceId">id of device we want to turn on</param>
        
        public void TurnOnDevice(string deviceId)
        {
            var device = _deviceRepository.GetDeviceById(deviceId);
            if (device == null)
            {
                throw new ArgumentException($"Device with ID {deviceId} not found.", nameof(deviceId));
            }
            device.TurnOn();
        }
        /// <summary>
        ///Turns off device if it exists by ID</summary>
        /// <param name="deviceId">id of device we want to turn off</param>
        public void TurnOffDevice(string deviceId)
        {
            var device = _deviceRepository.GetDeviceById(deviceId);
            if (device == null)
            {
                throw new ArgumentException($"Device with ID {deviceId} not found.", nameof(deviceId));
            }
            device.TurnOff();
        }
    }
}
