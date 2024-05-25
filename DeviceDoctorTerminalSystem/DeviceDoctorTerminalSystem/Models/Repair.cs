using DeviceDoctorTerminalSystem.Enumerations;
using DeviceDoctorTerminalSystem.Utilities;
using System.Data;

namespace DeviceDoctorTerminalSystem.Models
{
    public record Repair
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Customer Customer { get; init; } = new Customer();
        public Device Device { get; init; } = new Device();
        public string IssueDescription { get; set; } = string.Empty;
        public Status Status { get; private set; } = Status.Triaged;
        public List<string> Updates { get; private set; } = new();
        public DateTime DateCreated { get; init; } 
        public DateTime LastModifiedDate { get; private set; }
        
        public static Repair Create()
        {
            var repair = new Repair();
            repair.UpdateState(Status.Triaged);
            return repair;
        }      

        public void StartProgress() => UpdateState(Status.InProgress);

        public void Complete() => UpdateState(Status.Completed);

        public void Cancel() => UpdateState(Status.Cancelled);

        public void UpdateLog(string entry)
        {
            Updates.Add(FormatLogEntry(entry));
            RegisterUpdate();
        }

        private void UpdateState(Status status)
        {
            Status = status;
            Updates.Add(FormatLogEntry($"Repair {status.Description()}"));
            RegisterUpdate();
        }

        private void RegisterUpdate() => LastModifiedDate = DateTime.Now;

        private static string FormatLogEntry(string entry) => $"{DateTime.Now}: {entry}";
    }
}
