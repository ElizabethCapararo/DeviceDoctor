using DeviceDoctorTerminalSystem.Enumerations;

namespace DeviceDoctorTerminalSystem.Models
{
    public class Device
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; } = Status.Triage;
        public Dictionary<DateTime, string> Updates { get; set; } = new();

        public Device(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
