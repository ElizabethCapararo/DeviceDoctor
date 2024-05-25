using DeviceDoctorTerminalSystem.Enumerations;

namespace DeviceDoctorTerminalSystem.Models
{
    public class Repair
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required Customer Customer { get; init; }         
        public required Device Device { get; init; }
        public string IssueDescription { get; init; } = string.Empty;
        public Status Status { get; private set; } = Status.Triaged;
        public Dictionary<DateTime, string> Updates { get; set; } = new();
        public DateTime DateCreated => Updates.FirstOrDefault().Key;
        public DateTime LastModifiedDate => Updates.LastOrDefault().Key;

        public static Repair Create(
            Customer customer, 
            Device device,
            string issueDescription)
        {
            return new()
            {
                Customer = customer,
                Device = device,
                IssueDescription = issueDescription,
                Updates = new() { { DateTime.Now, "Device Triaged" } }
            };
        }

        public void StartProgress() => Status = Status.InProgress;

        public void Complete() => Status = Status.Completed;

        public void Cancel() => Status = Status.Cancelled;
    }
}
