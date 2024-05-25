using System.ComponentModel.DataAnnotations;

namespace DeviceDoctorTerminalSystem.Models
{
    public record Device
    {        
        public string SerialNumber { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public string Manufacturer { get; init; } = string.Empty;
        public string Condition { get; init; } = string.Empty;

        public static Device Create(
            string serialNumber,
            string model,
            string manufacturer,
            string deviceCondition)
        {
            return new()
            {
                SerialNumber = serialNumber,
                Model = model,
                Manufacturer = manufacturer,
                Condition = deviceCondition
            };
        }
    }
}
