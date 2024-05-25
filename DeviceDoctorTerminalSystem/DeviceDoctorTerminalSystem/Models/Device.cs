using DeviceDoctorTerminalSystem.Enumerations;

namespace DeviceDoctorTerminalSystem.Models
{
    public class Device
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required Customer Customer { get; init; } 
        public string SerialNumber { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public string Manufacturer { get; init; } = string.Empty;
        public string IssueDescription { get; init; } = string.Empty;
        public string DeviceCondition { get; init; } = string.Empty;
        public Status Status { get; private set; } = Status.Triaged;
        public Dictionary<DateTime, string> Updates { get; set; } = new();

        public static Device Create(
            Customer customer, 
            string serialNumber, 
            string model, 
            string manufacturer, 
            string issueDescription, 
            string deviceCondition)
        {
            return new()
            {
                Customer = customer,
                SerialNumber = serialNumber,
                Model = model,
                Manufacturer = manufacturer,
                IssueDescription = issueDescription,
                DeviceCondition = deviceCondition,
                Updates = new() { { DateTime.Now, "Device Triaged" } }
            };
        }

        public void StartProgress() => Status = Status.InProgress;

        public void Complete() => Status = Status.Completed;

        public void Cancel() => Status = Status.Cancelled;
    }
}
