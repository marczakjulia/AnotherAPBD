namespace AnotherAPBD
{
    /// <summary>
    /// Smartwatch class, yet not the logic of battery is in a separate class, same with id validation
    /// </summary>
    public class Smartwatch : Device, IPowerNotify
    {
        public static IIdValidator IdValidator { get; set; } = new SmartWatchIdValidator();
        public Battery Battery { get; private set; }

        public Smartwatch(string id, string name, bool isEnabled, int batteryLevel)
            : base(id, name, isEnabled)
        {
            IdValidator.ValidateOrThrow(id);
            Battery = new Battery(batteryLevel, this);
        }

        public void Notify(int batteryLevel)
        {
            Console.WriteLine($"Battery level is low. Current level is: {batteryLevel}%");
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
}