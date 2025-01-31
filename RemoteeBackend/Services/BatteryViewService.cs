using System.Management;

namespace RemoteAccess.Services
{
    public class BatteryService
    {
        public int GetBatteryStatus()
        {

        #pragma warning disable CA1416 // Validate platform compatibility
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");

            var queryCollection = searcher.Get();

            foreach (var queryObj in queryCollection)
            {

                var batteryLifePercent = queryObj["EstimatedChargeRemaining"];

                return Convert.ToInt32(batteryLifePercent);
            }
        #pragma warning restore CA1416 // Validate platform compatibility

            return -1;
        }
    }
}
