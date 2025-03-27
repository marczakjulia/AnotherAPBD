namespace AnotherAPBD
{
    public class Program
    {
        public static void Main()
        {
            //minor changes had to be done since now deviceService has the turning on logic, but as said in the file for homeowkr it is allowed
           try  {
                var deviceManager = DeviceManagerCreation.CreateDeviceManager("/Users/juliamarczak/RiderProjects/AnotherAPBD/AnotherAPBD/input.txt");
                var deviceService = new DeviceService(deviceManager);
                Console.WriteLine("Devices presented after file read.");
                deviceManager.ShowAllDevices();
                Console.WriteLine("Create new computer with correct data and add it to device store.");
                {
                    PersonalComputer computer = new PersonalComputer("P-2", "ThinkPad T440", false, null);
                    deviceManager.AddDevice(computer);
                }
                Console.WriteLine("Let's try to enable this PC");
                try
                {
                    deviceService.TurnOnDevice("P-2");
                }
                catch (EmptySystemException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Let's install OS for this PC");
                PersonalComputer editComputer = new PersonalComputer("P-2", "ThinkPad T440", true, "Arch Linux");
                deviceManager.EditDevice(editComputer);
                Console.WriteLine("Let's try to enable this PC");
                deviceService.TurnOnDevice("P-2");
                Console.WriteLine("Let's turn off this PC");
                deviceService.TurnOffDevice("P-2");
                Console.WriteLine("Delete this PC");
                deviceManager.RemoveDeviceById("P-2");
                Console.WriteLine("Devices presented after all operations:");
                deviceManager.ShowAllDevices();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
