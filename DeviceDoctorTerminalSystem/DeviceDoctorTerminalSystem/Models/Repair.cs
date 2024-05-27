using DeviceDoctorTerminalSystem.Enumerations;

namespace DeviceDoctorTerminalSystem.Models
{
    public record Repair
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Customer Customer { get; init; } = new Customer();
        public Device Device { get; init; } = new Device();
        public string IssueDescription { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Triaged;
        public List<string> Updates { get; set; } = new();
        public DateTime DateCreated { get; init; } 
        public DateTime LastModifiedDate { get; set; }
    }
}
