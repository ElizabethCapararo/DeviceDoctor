using System.ComponentModel.DataAnnotations;

namespace DeviceDoctorTerminalSystem.Models
{
    public record Device
    {        
        public string SerialNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
    }
}
